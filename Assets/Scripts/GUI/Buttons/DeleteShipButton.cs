using UnityEngine;
using System.Collections;

public class DeleteShipButton : MonoBehaviour {

  private Button button;
  public bool shipDeleted = false;
  
	void Start () {
    button = GetComponent<Button>();	
	}
	
	void Update () {
    shipDeleted = false;
	  if(GameControl.control.numberOfShips > 0) {
      if(button.ButtonClicked) {
        deleteShip();
      }
    }
	}

  void deleteShip() {
    GameControl.control.shipList.RemoveAt(GameControl.control.currentShipIndex);
    GameControl.control.numberOfShips--;
    GameControl.control.currentShipIndex--;
    if(GameControl.control.currentShipIndex < 0) {
      GameControl.control.currentShipIndex = 0;
    }
    shipDeleted = true;
  }
}
