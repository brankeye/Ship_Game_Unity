using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorkTool : MonoBehaviour {
  
  private ColorTool     colorTool;
  private List<Vector3> raycastDirections;
  private Button        okButton;
  private ShipFunctions shipFunctions;

  void Start() {
    raycastDirections = new List<Vector3>();
    raycastDirections.Add(Vector3.left);
    raycastDirections.Add(Vector3.up);
    raycastDirections.Add(Vector3.right);
    raycastDirections.Add(Vector3.down);

    shipFunctions = gameObject.GetComponent<ShipFunctions>();

    Button[] buttons = gameObject.GetComponentsInChildren<Button>();
    for(int i = 0; i < buttons.Length; i++) {
      if(buttons[i].gameObject.name.Equals("Ok Button")) {
        okButton = buttons[i];
      }
    }
  }

  void Update() {
    if(okButton.ButtonClicked) {
      UpdateModifiedShip();
    }
  }

  public void AddBlock(GameObject shipObject, Ship theShip, string blockType, Vector2 rayPosition, float blockRotation, Color newBlockColor) {
    if(shipFunctions.CheckBlock("Block", rayPosition, Vector3.forward, theShip.shipScale) == null) {
      float shipObjectScale = shipObject.transform.localScale.x;
      List<GameObject> blockList = shipFunctions.CheckBlocks("Block", rayPosition, raycastDirections, shipObjectScale);
      
      if(blockList.Count > 0) {
        Vector3 newBlockVector = Camera.main.ScreenToWorldPoint(rayPosition);
        float xPos = Mathf.Round(newBlockVector.x / shipObjectScale);
        float yPos = Mathf.Round(newBlockVector.y / shipObjectScale);
        newBlockVector = new Vector3(xPos, yPos, 1.0f);

        theShip.AddBlock(blockType, newBlockVector, blockRotation, newBlockColor);
        shipFunctions.CreateBlock(shipObject, blockType, newBlockVector, blockRotation, newBlockColor);
      }
    }
  }

  public void DeleteBlock(GameObject shipObject, Ship theShip, Vector2 rayPosition) {
    if(theShip.numberOfBlocks > 1) {
      GameObject targetBlock = shipFunctions.CheckBlock("Block", rayPosition, Vector3.forward, theShip.shipScale);
      if(targetBlock != null) {
        theShip.DeleteBlock(targetBlock.transform.localPosition);
        GameObject.Destroy(targetBlock);
      }
    }
  }

  public void UpdateModifiedShip() {
    GameControl.control.shipList [GameControl.control.currentShipIndex] = GetComponent<ToolHandler>().TemporaryShip;
  }
}
