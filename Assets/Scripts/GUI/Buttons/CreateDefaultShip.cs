using UnityEngine;
using System.Collections;

public class CreateDefaultShip : MonoBehaviour {
  SelectColor selectColor;
  Button button;

  void Start() {
    selectColor = GetComponent<SelectColor>();
    button = GetComponent<Button>();
  }

  void Update() {
    if(selectColor.getColor) {
      Ship newDefaultShip = new Ship();
      newDefaultShip.AddBlock(new Vector3(0,0,0), selectColor.newColor);
      selectColor.getColor = false;

      GameControl.control.shipList.Add(newDefaultShip);
      GameControl.control.numberOfShips++;
    }
  }
}
