using UnityEngine;
using System.Collections;

public class ToolHandler : MonoBehaviour {

  private ViewTool viewTool;
  private ColorTool colorTool;
  private bool useViewTool = false;
  private bool launchColorTool = false;
  private GameObject ship;

  public bool UsingViewTool {
    get { return useViewTool; }
  }

  public bool UsingColorTool {
    get { return (colorTool.DrawingSelector); }
  }

  void Start () {
    viewTool = gameObject.AddComponent("ViewTool") as ViewTool;
    colorTool = gameObject.AddComponent("ColorTool") as ColorTool;
	}
	
	void Update () {
    HandleViewTool();
    HandleColorTool();
	}

  void HandleViewTool() {
    if (GameControl.control.numberOfShips > 0 && 
        (Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetMouseButton(0))
    {
      useViewTool = true;
      if(ship == null) {
        ship = GameObject.FindWithTag("Ship");
      }
      viewTool.MoveGameObject(ship);
    } else {
      useViewTool = false;
    }
  }

  void HandleColorTool() {
    if(Input.GetKeyDown(KeyCode.C) || (Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl))) {
      launchColorTool = true;
    }

    if (launchColorTool) {
      colorTool.SelectNewColor();
      launchColorTool = false;
    }
  }
}
