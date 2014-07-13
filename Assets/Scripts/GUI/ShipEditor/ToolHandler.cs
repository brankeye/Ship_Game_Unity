using UnityEngine;
using System.Collections;

public class ToolHandler : MonoBehaviour {

  private ViewTool viewTool;
  private GameObject ship;

  void Start () {
    gameObject.AddComponent("ViewTool");
    viewTool = GetComponent<ViewTool>();
	}
	
	void Update () {
    if (GameControl.control.numberOfShips > 0 && 
        (Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetMouseButton(0))
    {
      if(ship == null) {
        ship = GameObject.FindWithTag("Ship");
      }
      viewTool.MoveGameObject(ship);
    }
	}
}
