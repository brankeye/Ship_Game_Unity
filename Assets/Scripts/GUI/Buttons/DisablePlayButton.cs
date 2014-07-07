using UnityEngine;
using System.Collections;

public class DisablePlayButton : MonoBehaviour {

  Button button;
  
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
