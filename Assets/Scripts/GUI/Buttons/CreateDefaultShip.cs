// Name: CreateDefaultShip.cs
// Purpose: create a new ship of a user selected color.

using UnityEngine;
using System.Collections;

public class CreateDefaultShip : MonoBehaviour {

  // the create button creates a one block ship for the user
  private Button createButton;
  // color functions handles the selecting of a color
  private ColorFunctions colorFunctions;
  private bool drawColorSelector;
  private bool selectionComplete;
  private Color selectedColor;

  void Start() {
    drawColorSelector = false;
    selectionComplete = false;

    createButton = GetComponent<Button>();
    colorFunctions = GetComponent<ColorFunctions>();
  }

  void Update() {
    // if the create button is clicked, launch the color selector
    if(createButton.ButtonClicked) {
      drawColorSelector = true;
    }

    // let the user select a color
    if(drawColorSelector) {
      if(colorFunctions.DrawColorPicker(selectedColor)) {
        selectedColor = colorFunctions.NewColor;
        selectionComplete = true;
        drawColorSelector = false;
      }
    }

    // once a color is selected, create a new one block ship for them and add it to the end of the ship list
    if(selectionComplete) {
      Ship newDefaultShip = new Ship(new Vector3(0,0,0), selectedColor);

      GameControl.control.shipList.Add(newDefaultShip);
      GameControl.control.numberOfShips++;
      GameControl.control.currentShipIndex = GameControl.control.numberOfShips - 1;

      selectionComplete = false;
    }
  }
}
