using UnityEngine;
using System.Collections;

public class MuteSound : MonoBehaviour {
	
  private Toggle toggle;
  public int sound = 1;

  void Start() {
    // sound enabled by default, 1 = true, -1 = false
    PlayerPrefs.SetInt("SoundEnabled", 1);
    sound = PlayerPrefs.GetInt("SoundEnabled");
    toggle = GetComponent<Toggle>();
  }

	void Update () {
	  if(toggle.ToggleClicked) {
      PlayerPrefs.SetInt("SoundEnabled", PlayerPrefs.GetInt("SoundEnabled") * -1);
      sound = PlayerPrefs.GetInt("SoundEnabled");
    }
	}
}
