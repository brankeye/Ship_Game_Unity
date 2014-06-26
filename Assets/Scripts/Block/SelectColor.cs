using UnityEngine;
using System.Collections;

public class SelectColor : MonoBehaviour {
	
  Button button;
  public Color newColor = Color.white;
  private bool drawColorPicker = false;
  public bool getColor = false;

  void Start() {
    button = GetComponent<Button>();
  }
  
	void Update () {
    if(button.ButtonClicked) {
      drawColorPicker = true;
    }
	}

  void OnGUI() {
    if(drawColorPicker) {
      newColor = ColorPicker(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 70, 200, 140), newColor);
    }
  }

  public Color ColorPicker(Rect rect, Color color)
  {
    //Create a blank texture.
    Texture2D tex = new Texture2D(40,40);

    GUILayout.BeginArea(rect,"","Box");
    
    #region Slider block
    GUILayout.BeginHorizontal();
    GUILayout.BeginVertical("Box");
    //Sliders for rgb variables betwen 0.0 and 1.0
    GUILayout.BeginHorizontal();
    GUILayout.Label("R",GUILayout.Width(10));
    color.r = GUILayout.HorizontalSlider(color.r,0f,1f);
    GUILayout.EndHorizontal();
    
    GUILayout.BeginHorizontal();
    GUILayout.Label("G",GUILayout.Width(10));
    color.g = GUILayout.HorizontalSlider(color.g,0f,1f);
    GUILayout.EndHorizontal();
    
    GUILayout.BeginHorizontal();
    GUILayout.Label("B",GUILayout.Width(10));
    color.b = GUILayout.HorizontalSlider(color.b,0f,1f);
    GUILayout.EndHorizontal();
    GUILayout.EndVertical();
    #endregion
    
    //Color Preview
    GUILayout.BeginVertical("Box",new GUILayoutOption[]{GUILayout.Width(44),GUILayout.Height(44)});
    //Apply color to following label
    GUI.color = color;
    GUILayout.Label(tex);
    //Revert color to white to avoid messing up any following controls.
    GUI.color = Color.white;
    
    GUILayout.EndVertical();
    GUILayout.EndHorizontal();
    
    //Give color as RGB values.
    GUILayout.Label("(R, G, B) = (" + (int)(color.r * 255) + ", " + (int)(color.g * 255) + ", " + (int)(color.b * 255) + ")");

    if (GUI.Button(new Rect(20, 110, 75, 25), "OK")) {
      drawColorPicker = false;
      getColor = true;
    }

    if (GUI.Button(new Rect(105, 110, 75, 25), "CANCEL")) {
      drawColorPicker = false;
      getColor = false;
    }

    GUILayout.EndArea();
    //Finally return the modified value.
    return color;
  }
}