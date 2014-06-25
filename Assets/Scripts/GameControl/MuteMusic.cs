using UnityEngine;
using System.Collections;

public class MuteMusic : MonoBehaviour {

  private Toggle toggle;
  public int music = 1;
  
  void Start() {
    // sound enabled by default, 1 = true, -1 = false
    PlayerPrefs.SetInt("MusicEnabled", 1);
    music = PlayerPrefs.GetInt("MusicEnabled");
    toggle = GetComponent<Toggle>();
  }
  
  void Update () {
    if(toggle.ToggleClicked) {
      PlayerPrefs.SetInt("MusicEnabled", PlayerPrefs.GetInt("MusicEnabled") * -1);
      music = PlayerPrefs.GetInt("MusicEnabled");
    }
  }
}
