using UnityEngine;
using System.Collections;

public class ShipScrollButton : MonoBehaviour {

  public enum ScrollDirection { Positive, Negative };
  public ScrollDirection scrollDirection;
  private Button button;

	// Use this for initialization
	void Start () {
    button = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	  if(button.ButtonClicked) {
      int tempShipIndex = GameControl.control.currentShipIndex;

      if(scrollDirection == ScrollDirection.Positive) {
        if(tempShipIndex + 1 < GameControl.control.numberOfShips) {
          GameControl.control.currentShipIndex++;
        } else {
          GameControl.control.currentShipIndex = 0;
        }
      } else {
        if(tempShipIndex - 1 >= 0) {
          GameControl.control.currentShipIndex--;
        } else {
          GameControl.control.currentShipIndex = GameControl.control.numberOfShips - 1;
        }
      }
    }
	}
}
