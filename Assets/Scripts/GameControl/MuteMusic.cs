// Name: MuteMusic.cs
// Purpose: mute the music

using UnityEngine;
using System.Collections;

public class MuteMusic : MonoBehaviour {

  private Toggle toggle;
  
  void Start() {
    toggle = GetComponent<Toggle>();
  }
  
  void Update () {
    if (toggle.ToggleClicked) {
      GameControl.control.musicEnabled = !GameControl.control.musicEnabled;
    }
  }
}
