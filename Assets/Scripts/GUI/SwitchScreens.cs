using UnityEngine;
using System.Collections;

public class SwitchScreens : MonoBehaviour {
	
	public GameObject targetScreen;
  public GameObject thisScreen;
	private Button button;
  private bool switchScreens = false;

	void Start () {
		button = gameObject.GetComponent<Button> ();
	}

	void Update () {
    if(switchScreens) {
      GameObject screen = Instantiate(Resources.Load("Screens/" + targetScreen.name)) as GameObject;
      screen.transform.parent = thisScreen.transform.parent.transform;
      Destroy(thisScreen);
    }
		if(button.ButtonClicked) {
      switchScreens = true;
		}
	}
}
