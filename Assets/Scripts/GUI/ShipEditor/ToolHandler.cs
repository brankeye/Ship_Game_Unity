using UnityEngine;
using System.Collections;

public class ToolHandler : MonoBehaviour {

  private ViewTool  viewTool;
  private ColorTool colorTool;
  private ZoomTool  zoomTool;

  private bool usingViewTool = false;
  private bool launchColorTool = false;
  private GameObject ship;

  private bool usingTool = false;
  public bool UsingTool {
    get { return usingTool; }
  }

  public bool UsingViewTool {
    get { return usingViewTool; }
  }

  public bool UsingColorTool {
    get { return (colorTool.DrawingSelector); }
  }

  void Start () {
    viewTool = gameObject.AddComponent("ViewTool") as ViewTool;
    colorTool = gameObject.AddComponent("ColorTool") as ColorTool;
    zoomTool = gameObject.AddComponent("ZoomTool") as ZoomTool;
	}
	
	void Update () {
    if(ship == null) {
      ship = GameObject.FindWithTag("Ship");
    }

    HandleViewTool();
    HandleColorTool();
    HandleZoomTool();

    if(usingViewTool || UsingColorTool) {
      usingTool = true;
    } else {
      usingTool = false;
    }
	}

  void HandleViewTool() {
    if (GameControl.control.numberOfShips > 0 && 
        Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButton(0))
    {
      usingViewTool = true;
      viewTool.MoveGameObject(ship);
    } else {
      usingViewTool = false;
    }
  }

  void HandleColorTool() {
    if(Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.LeftShift)) {
      launchColorTool = true;
    }

    if (launchColorTool) {
      colorTool.SelectNewColor();
      launchColorTool = false;
    }
  }

  void HandleZoomTool() {
    if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.KeypadPlus)) {
      zoomTool.ZoomIn(ship);
    }
    if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.KeypadMinus)) {
      zoomTool.ZoomOut(ship);
    }
  }
}
