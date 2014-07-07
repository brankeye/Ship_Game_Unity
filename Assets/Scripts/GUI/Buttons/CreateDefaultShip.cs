using UnityEngine;
using System.Collections;

public class CreateDefaultShip : MonoBehaviour {

  SelectColor selectColor;

  void Start() {
    selectColor = GetComponent<SelectColor>();
  }

  void Update() {
    if(selectColor.getColor) {
      Ship newDefaultShip = new Ship(new Vector3(0,0,0), selectColor.newColor);
      selectColor.getColor = false;

      GameControl.control.shipList.Add(newDefaultShip);
      GameControl.control.numberOfShips++;
      GameControl.control.currentShipIndex = GameControl.control.numberOfShips - 1;
    }
  }
}
