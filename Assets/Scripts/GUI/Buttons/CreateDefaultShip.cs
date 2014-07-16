// Name: CreateDefaultShip.cs
// Purpose: create a new ship of a user selected color.

using UnityEngine;
using System.Collections;

public class CreateDefaultShip : MonoBehaviour {

  // the create button creates a one block ship for the user
  private Button createButton;
  // color functions handles the selecting of a color
  private ColorTool colorTool;
  private bool drawColorSelector;

  void Start() {
    drawColorSelector = false;

    createButton = GetComponent<Button>();
    colorTool = GetComponent<ColorTool>();
  }

  void Update() {
    // if the create button is clicked, launch the color selector
    if(createButton.ButtonClicked) {
      drawColorSelector = true;
    }

    // let the user select a color
    if(drawColorSelector) {
      colorTool.SelectNewColor();
      if(colorTool.SelectionCompleted) {
        drawColorSelector = false;

        // once a color is selected, create a new one block ship for them and add it to the end of the ship list
        if(!colorTool.SelectionCanceled ) {
          Ship newDefaultShip = new Ship("Blocks/Block00", new Vector3(0,0,0), colorTool.NewColor);
          
          GameControl.control.shipList.Add(newDefaultShip);
          GameControl.control.numberOfShips++;
          GameControl.control.currentShipIndex = GameControl.control.numberOfShips - 1;
        }
      }
    }
  }
}
