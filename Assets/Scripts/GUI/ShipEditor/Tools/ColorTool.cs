using UnityEngine;
using System.Collections;

public class ColorTool : MonoBehaviour {

  private ColorFunctions colorFunctions;
  private Color newColor;
  private bool selectColor;
  private bool colorSelected = false;

  public Color NewColor {
    get { return newColor; }
  }

  public bool SelectionCompleted {
    get { return colorSelected; }
  }

  public bool SelectionCanceled {
    get { return colorFunctions.CancelPressed; }
  }

  public bool SelectorRendering {
    get { return colorFunctions.DrawingSelector; }
  }

	// Use this for initialization
	void Start () {
    colorFunctions = gameObject.AddComponent("ColorFunctions") as ColorFunctions;
    newColor = Color.white;
    selectColor = false;
	}
	
	// Update is called once per frame
	void Update () {
    colorSelected = false;
    // let the user select a color
    if(selectColor) {
      colorSelected = colorFunctions.DrawColorPicker(newColor);
      if(colorSelected) {
        newColor = colorFunctions.NewColor;
        selectColor = false;
      }
    }
	}

  public void SelectNewColor() {
    if(!colorSelected) {
      selectColor = true;
    }
  }
}
