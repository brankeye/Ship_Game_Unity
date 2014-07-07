using UnityEngine;
using System.Collections;

public class DisableEditButton : MonoBehaviour {
  
  Button button;
  
  // Use this for initialization
  void Start () {
    button = GetComponent<Button>();
    
    if(GameControl.control.numberOfShips <= 0) {
      button.disableButton();
    } else {
      button.enableButton();
    }
  }
  
  void Update() {
    if(GameControl.control.numberOfShips > 0) {
      button.enableButton();
    } else {
      button.disableButton();
    }
  }
}
