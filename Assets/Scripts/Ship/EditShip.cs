using UnityEngine;
using System.Collections;

public class EditShip : MonoBehaviour {

  private ShipFunctions shipFunctions;
  private Ship theShip;
  private GameObject editedShip;
  private bool shipEdited = false;
  private bool shipInitiated = false;

  private Vector3 blockVector;
  private Color   blockColor;

  public bool shipWasChanged = false;

  private Camera theCamera;
  private GameObject highlightedBlock;
  private GameObject selectedGameObject;
  private Vector3[] raycastDirections;
  private bool clickActive = false;
  private bool addNewBlock = false;

  void Start() {
    raycastDirections = new Vector3[5];
    raycastDirections [0] = Vector3.forward;
    raycastDirections [1] = Vector3.left;
    raycastDirections [2] = Vector3.up;
    raycastDirections [3] = Vector3.right;
    raycastDirections [4] = Vector3.down;
    theCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    shipFunctions = GetComponent<ShipFunctions>();
  }

	void Update () {
    if (GameControl.control.numberOfShips > 0)
    {
      if (!shipInitiated)
      {
        if(editedShip != null) {
          Destroy(editedShip);
        }

        theShip = new Ship(GameControl.control.shipList [GameControl.control.currentShipIndex]);
        editedShip = shipFunctions.CreateShip(theShip, "Ventura");
        editedShip.transform.parent = transform;

        shipInitiated = true;
      }

      if (Input.GetKeyDown(KeyCode.UpArrow))
      {
        blockVector = new Vector3(0, theShip.largestY + 1, 0);
        blockColor = Color.blue;
        theShip.AddBlock(blockVector, blockColor);
        shipEdited = true;
      } else if (Input.GetKeyDown(KeyCode.DownArrow))
      {
        blockVector = new Vector3(0, theShip.smallestY - 1, 0);
        blockColor = Color.blue;
        theShip.AddBlock(blockVector, blockColor);
        shipEdited = true;
      } else if (Input.GetKeyDown(KeyCode.LeftArrow))
      {
        blockVector = new Vector3(theShip.smallestX - 1, 0, 0);
        blockColor = Color.blue;
        theShip.AddBlock(blockVector, blockColor);
        shipEdited = true;
      } else if (Input.GetKeyDown(KeyCode.RightArrow))
      {
        blockVector = new Vector3(theShip.largestX + 1, 0, 0);
        blockColor = Color.blue;
        theShip.AddBlock(blockVector, blockColor);
        shipEdited = true;
      }

      if(blockWasSelected()) {
        createHighlightedBlock();
      }

      Vector2 rayPosition = Vector2.zero;

      if(Input.touchCount > 0 || Input.GetMouseButton(0)) {
        if(Input.touchCount > 0) {
          rayPosition = Input.touches[0].position;
        } else {
          rayPosition = Input.mousePosition;
        }

        Ray ray = theCamera.ScreenPointToRay(rayPosition);

        for(int i = 0; i < raycastDirections.Length; i++) {
          RaycastHit2D hit = Physics2D.Raycast(ray.origin, raycastDirections[i], 1.0f);
          if(hit.collider != null && !clickActive) {
            if(hit.collider.gameObject.tag == "Block") {
              addNewBlock = true;
            }
          }
        }
        clickActive = true;
      } else {
        clickActive = false;
      }

      Vector2 mousePos;
      if(addNewBlock) {
        mousePos = Camera.main.ScreenToWorldPoint(rayPosition);
        mousePos = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
        Debug.Log(mousePos.ToString());
        blockVector = new Vector3(mousePos.x, mousePos.y, -1);
        blockColor = Color.red;
        theShip.AddBlock(blockVector, blockColor);
        shipEdited = true;
        
        addNewBlock = false;
      }

      if (shipEdited)
      {
        if(editedShip != null) {
          Destroy(editedShip);
        }
        editedShip = shipFunctions.CreateShip(theShip, "Ventura");
        editedShip.transform.parent = transform;

        shipEdited = false;
      }
    }
	}

  public void updateModifiedShip() {
    GameControl.control.shipList [GameControl.control.currentShipIndex] = theShip;
    shipInitiated = false;
    shipWasChanged = true;
  }

  public void cancelCurrentModifications() {
    shipInitiated = false;
  }

  private bool blockWasSelected() {
    if(Input.touchCount > 0 || Input.GetMouseButton(0)) {
      Vector2 rayPosition;
      if(Input.touchCount > 0) {
        rayPosition = Input.touches[0].position;
      } else {
        rayPosition = Input.mousePosition;
      }
      
      Ray ray = theCamera.ScreenPointToRay(rayPosition);
      RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
      
      // if the user touched the button, change the button state accordingly
      if(hit.collider != null) {
        selectedGameObject = hit.collider.gameObject;
        if(selectedGameObject != null && selectedGameObject.tag == "Block") {
          return true;
        }
      }
    }
    return false;
  }

  private void createHighlightedBlock() {
    if(highlightedBlock != null) {
      Destroy(highlightedBlock);
    }
    highlightedBlock = Instantiate(Resources.Load("Highlighted Block")) as GameObject;
    highlightedBlock.transform.parent = transform.parent.transform;
    highlightedBlock.transform.position = new Vector3(selectedGameObject.transform.position.x,
                                                      selectedGameObject.transform.position.y,
                                                      0);
    highlightedBlock.transform.localScale = new Vector3(selectedGameObject.transform.parent.localScale.x,
                                                        selectedGameObject.transform.parent.localScale.y,
                                                        0);
  }
}
