using UnityEngine;
using System.Collections;

public class DisablePlayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	  if(GameControl.control.numberOfShips <= 0) {
      gameObject.GetComponent<Button>().ButtonDisabled = true;
    }
	}

  void Update() {
    if(GameControl.control.numberOfShips > 0) {
      gameObject.GetComponent<Button>().ButtonDisabled = false;
    }
  }
}
