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

  void Start() {
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

      if(transform.parent.position.z == 0) {
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
}
