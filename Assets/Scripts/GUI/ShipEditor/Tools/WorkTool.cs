﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorkTool : MonoBehaviour {
  
  private ColorTool     colorTool;
  private List<Vector3> raycastDirections;
  private Button        okButton;
  private ShipFunctions shipFunctions;

  void Start() {
    Button[] buttons = gameObject.GetComponentsInChildren<Button>();
    for(int i = 0; i < buttons.Length; i++) {
      string buttonName = buttons[i].gameObject.name;
      if(buttonName == "Ok Button") {
        okButton = buttons[i];
      }
    }

    raycastDirections = new List<Vector3>();
    raycastDirections.Add(Vector3.left);
    raycastDirections.Add(Vector3.up);
    raycastDirections.Add(Vector3.right);
    raycastDirections.Add(Vector3.down);

    shipFunctions = gameObject.GetComponent<ShipFunctions>();
  }

  void Update() {
    if(okButton.ButtonClicked) {
      UpdateModifiedShip();
    }
  }

  public void AddBlock(GameObject shipObject, Ship theShip, Vector2 rayPosition, Color newBlockColor) {
    if(shipFunctions.CheckBlock("Block", rayPosition, Vector3.forward, theShip.shipScale) == null) {
      float shipObjectScale = shipObject.transform.localScale.x;
      List<GameObject> blockList = shipFunctions.CheckBlocks("Block", rayPosition, raycastDirections, shipObjectScale);
      
      if(blockList.Count > 0) {
        Vector3 newBlockVector = Camera.main.ScreenToWorldPoint(rayPosition);
        float xPos = Mathf.Round(newBlockVector.x / shipObjectScale);
        float yPos = Mathf.Round(newBlockVector.y / shipObjectScale);
        newBlockVector = new Vector3(xPos, yPos, 1.0f);

        theShip.AddBlock(newBlockVector, newBlockColor);
        shipFunctions.CreateBlock(shipObject, newBlockVector, newBlockColor);
      }
    }
  }

  public void DeleteBlock() {

  }

  public void UpdateModifiedShip() {
    GameControl.control.shipList [GameControl.control.currentShipIndex] = GetComponent<ToolHandler>().TemporaryShip;
  }
}
