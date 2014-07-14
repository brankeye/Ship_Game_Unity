// Name: ColorFunctions.cs
// Purpose: get a Color from the user.

using UnityEngine;
using System.Collections;

public class ColorFunctions : MonoBehaviour {

  // the color retrieved from the selector
  private Color color;
  // in case user cancels color selector, save old color
  private Color oldColor;
  private bool oldColorSaved;
  public bool renderColorPicker;
  private bool colorSelected;
  private Rect rect;

  public Color NewColor {
    get { return color; }
  }

  public bool ColorSelectionComplete {
    get { return colorSelected; }
  }

  public bool DrawingSelector {
    get { return renderColorPicker; }
  }

  void Start() {
    color = Color.white;
    oldColor = color;
    renderColorPicker = false;
    colorSelected = false;
    oldColorSaved = false;
  }

  void OnGUI() {
    if(renderColorPicker) {
      color = ColorPicker(color);
    }
  }
  
  // Function: DrawColorPicker
  // Purpose: draw a color selector for the user and retrive a user selected color.
  public bool DrawColorPicker(Color newColor) {
    // ColorPicker() will now be called from OnGUI()
    // the color selector will be rendered
    renderColorPicker = true;

    // if the user has selected a color, stop drawing the color selector
    if(colorSelected) {
      colorSelected = false;
      renderColorPicker = false;
      oldColorSaved = false;
      return true;
    }

    // if the user hasn't selected a color yet
    return false;
  }

  // Function: ColorPicker(Color newColor)
  // Purpose: draw a color selector for the user and allow them to select a color
  private Color ColorPicker(Color newColor)
  {
    if(!oldColorSaved) {
      oldColor = newColor;
      oldColorSaved = true;
    }

    //Create a blank texture.
    Texture2D tex = new Texture2D(40,40);

    Rect rect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 70, 200, 140);
    GUILayout.BeginArea(rect,"","Box");
    
    #region Slider block
    GUILayout.BeginHorizontal();
    GUILayout.BeginVertical("Box");
    //Sliders for rgb variables betwen 0.0 and 1.0
    GUILayout.BeginHorizontal();
    GUILayout.Label("R",GUILayout.Width(10));
    newColor.r = GUILayout.HorizontalSlider(newColor.r,0f,1f);
    GUILayout.EndHorizontal();
    
    GUILayout.BeginHorizontal();
    GUILayout.Label("G",GUILayout.Width(10));
    newColor.g = GUILayout.HorizontalSlider(newColor.g,0f,1f);
    GUILayout.EndHorizontal();
    
    GUILayout.BeginHorizontal();
    GUILayout.Label("B",GUILayout.Width(10));
    newColor.b = GUILayout.HorizontalSlider(newColor.b,0f,1f);
    GUILayout.EndHorizontal();
    GUILayout.EndVertical();
    #endregion
    
    //Color Preview
    GUILayout.BeginVertical("Box",new GUILayoutOption[]{GUILayout.Width(44),GUILayout.Height(44)});
    //Apply color to following label
    GUI.color = newColor;
    GUILayout.Label(tex);
    //Revert color to white to avoid messing up any following controls.
    GUI.color = Color.white;
    
    GUILayout.EndVertical();
    GUILayout.EndHorizontal();
    
    //Give color as RGB values.
    GUILayout.Label("(R, G, B) = (" + (int)(newColor.r * 255) + ", " + (int)(newColor.g * 255) + ", " + (int)(newColor.b * 255) + ")");

    if (GUI.Button(new Rect(20, 110, 75, 25), "OK")) {
      colorSelected = true;
    } else if (GUI.Button(new Rect(105, 110, 75, 25), "CANCEL")) {
      newColor = oldColor;
      colorSelected = true;
    }

    GUILayout.EndArea();

    //Finally return the modified value.
    return newColor;
  }
}