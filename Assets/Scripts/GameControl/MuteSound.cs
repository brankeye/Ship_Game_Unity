using UnityEngine;
using System.Collections;

public class MuteSound : MonoBehaviour {
	
  private Toggle toggle;

  void Start() {
    toggle = GetComponent<Toggle>();
  }

	void Update () {
	  if(toggle.ToggleClicked) {
      GameControl.control.soundEnabled = !GameControl.control.soundEnabled;
    }
	}
}
