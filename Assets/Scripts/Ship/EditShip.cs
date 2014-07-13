using UnityEngine;
using System.Collections;

public class EditShip : MonoBehaviour {

  private ShipFunctions shipFunctions;
  private Ship theShip;
  private GameObject shipObject;

  public bool shipWasChanged = false;

  private Camera theCamera;
  private Vector3[] raycastDirections;
  private bool clickActive = false;

  void Start() {
    raycastDirections = new Vector3[5];
    raycastDirections [0] = Vector3.forward;
    raycastDirections [1] = Vector3.left;
    raycastDirections [2] = Vector3.up;
    raycastDirections [3] = Vector3.right;
    raycastDirections [4] = Vector3.down;
    theCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    shipFunctions = GetComponent<ShipFunctions>();

    if (GameControl.control.numberOfShips > 0) {
      theShip = new Ship(GameControl.control.shipList [GameControl.control.currentShipIndex]);
      shipObject = shipFunctions.CreateShip(theShip, "Ventura");
      shipObject.transform.parent = transform;
    }
  }

	void Update () {
    if (GameControl.control.numberOfShips > 0)
    {
      Vector2 rayPosition = Vector2.zero;

      if(Input.touchCount > 0 || Input.GetMouseButton(0)) {
        if(Input.touchCount > 0) {
          rayPosition = Input.touches[0].position;
        } else {
          rayPosition = Input.mousePosition;
        }

        Ray ray = theCamera.ScreenPointToRay(rayPosition);

        for(int i = 0; i < raycastDirections.Length; i++) {
          RaycastHit2D hit = Physics2D.Raycast(ray.origin, raycastDirections[i], shipObject.transform.localScale.x);
          //Debug.Log(theShip.shipScale);
          if(hit.collider != null && !clickActive) {
            if(hit.collider.gameObject.tag == "Block") {
              if(i == 0) { // already a block at position of click
                break;
              }
              Vector3 newBlockPosition;
              switch(i) {
                case 1: // left
                  newBlockPosition = hit.collider.gameObject.transform.position;
                  newBlockPosition = new Vector3(newBlockPosition.x + 1.0f, newBlockPosition.y, newBlockPosition.z);
                  createNewBlock(newBlockPosition);
                  break;
                case 2: // up
                  newBlockPosition = hit.collider.gameObject.transform.position;
                  newBlockPosition = new Vector3(newBlockPosition.x, newBlockPosition.y - 1.0f, newBlockPosition.z);
                  createNewBlock(newBlockPosition);
                  break;
                case 3: // right
                  newBlockPosition = hit.collider.gameObject.transform.position;
                  newBlockPosition = new Vector3(newBlockPosition.x - 1.0f, newBlockPosition.y, newBlockPosition.z);
                  createNewBlock(newBlockPosition);
                  break;
                case 4: // down
                  newBlockPosition = hit.collider.gameObject.transform.position;
                  newBlockPosition = new Vector3(newBlockPosition.x, newBlockPosition.y + 1.0f, newBlockPosition.z);
                  createNewBlock(newBlockPosition);
                  break;
                default:
                  break;
              }

              break;
            }
          }
        }
        clickActive = true;
      } else {
        clickActive = false;
      }
    }
	}

  public void updateModifiedShip() {
    GameControl.control.shipList [GameControl.control.currentShipIndex] = theShip;
    shipWasChanged = true;
  }

  private void createNewBlock(Vector3 blockVector) {
    Color blockColor = Color.red;
    theShip.AddBlock(blockVector, blockColor);

    shipFunctions.CreateBlock(shipObject, blockVector, blockColor);
  }
}
