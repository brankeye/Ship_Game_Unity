using UnityEngine;
using System.Collections;

public class ToolHandler : MonoBehaviour {

  // for all tools
  private Ship          theShip;
  private GameObject    shipObject;
  private ShipFunctions shipFunctions;

  public Ship TemporaryShip {
    get { return theShip; }
  }

  private bool usingTool = false;
  public bool UsingTool {
    get { return usingTool; }
  }

  // for view tool
  private ViewTool  viewTool;
  private bool usingViewTool = false;

  public bool UsingViewTool {
    get { return usingViewTool; }
  }

  // for color tool
  private ColorTool colorTool;
  private bool launchColorTool = false;

  public bool UsingColorTool {
    get { return colorTool.SelectorRendering; }
  }
  
  // for zoom tool
  private ZoomTool  zoomTool;

  // for work tool
  private WorkTool  workTool;
  private bool clickActive = false;

  // for type tool
  private TypeTool typeTool;

  void Start () {
    workTool  = gameObject.AddComponent("WorkTool")  as WorkTool;
    viewTool  = gameObject.AddComponent("ViewTool")  as ViewTool;
    colorTool = gameObject.AddComponent("ColorTool") as ColorTool;
    zoomTool  = gameObject.AddComponent("ZoomTool")  as ZoomTool;
    typeTool  = gameObject.AddComponent("TypeTool")  as TypeTool;

    shipFunctions = gameObject.AddComponent("ShipFunctions") as ShipFunctions;

    if (GameControl.control.numberOfShips > 0) {
      theShip = new Ship(GameControl.control.shipList [GameControl.control.currentShipIndex]);
      shipObject = shipFunctions.CreateShip(theShip, "Ventura");
      shipObject.transform.parent = transform;
    }
	}
	
	void Update () {
    HandleViewTool();
    HandleColorTool();
    HandleZoomTool();
    HandleTypeTool();

    if(usingViewTool || UsingColorTool) {
      usingTool = true;
    } else {
      usingTool = false;
    }

    HandleWorkTool();
	}

  void HandleViewTool() {
    if (GameControl.control.numberOfShips > 0 && 
        Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButton(0))
    {
      usingViewTool = true;
      viewTool.MoveGameObject(shipObject);
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
      zoomTool.ZoomIn(shipObject);
    }
    if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.KeypadMinus)) {
      zoomTool.ZoomOut(shipObject);
    }
  }

  void HandleWorkTool() {
    if (GameControl.control.numberOfShips > 0 && !usingTool) {
      if(!Input.GetKey(KeyCode.LeftShift)) {
        if(Input.touchCount > 0) {
          if(!clickActive) {
            workTool.AddBlock(shipObject, theShip, typeTool.CurrentType, Input.touches[0].position, colorTool.NewColor);
          }
          clickActive = true;
        } else if(Input.GetMouseButtonDown(0)) {
          if(!clickActive) {
            workTool.AddBlock(shipObject, theShip, typeTool.CurrentType, Input.mousePosition, colorTool.NewColor);
          }
          clickActive = true;
        } else {
          clickActive = false;
        }
      } else if(Input.GetKey(KeyCode.D)) {
        if(Input.touchCount > 0) {
          if(!clickActive) {
            workTool.DeleteBlock(shipObject, theShip, Input.touches[0].position);
          }
          clickActive = true;
        } else if(Input.GetMouseButtonDown(1)) {
          if(!clickActive) {
            workTool.DeleteBlock(shipObject, theShip, Input.mousePosition);
          }
          clickActive = true;
        } else {
          clickActive = false;
        }
      }
    }
  }

  void HandleTypeTool() {
    if(Input.GetKey(KeyCode.LeftShift)) {
      if(Input.GetKey(KeyCode.Alpha1)) {
        typeTool.SelectBlockType(0);
      } else if(Input.GetKey(KeyCode.Alpha2)) {
        typeTool.SelectBlockType(1);
      } else if(Input.GetKey(KeyCode.Alpha3)) {
        typeTool.SelectBlockType(2);
      } else if(Input.GetKey(KeyCode.Alpha4)) {
        typeTool.SelectBlockType(3);
      } else if(Input.GetKey(KeyCode.Alpha5)) {
        typeTool.SelectBlockType(4);
      } 
    }
  }
}
