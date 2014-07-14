using UnityEngine;
using System.Collections;

public class ColorTool : MonoBehaviour {

  ColorFunctions colorFunctions;
  private Color newColor;
  private bool selectColor;

  public Color NewColor {
    get { return newColor; }
  }

  public bool DrawingSelector {
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
    // let the user select a color
    if(selectColor) {
      if(colorFunctions.DrawColorPicker(newColor)) {
        newColor = colorFunctions.NewColor;
        selectColor = false;
      }
    }
	}

  public void SelectNewColor() {
    selectColor = true;
  }
}
