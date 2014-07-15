using UnityEngine;
using System.Collections;

public class SwitchScreens : MonoBehaviour {
	
	public GameObject targetScreen;
  public GameObject thisScreen;
	private Button button;

	void Start () {
		button = gameObject.GetComponent<Button> ();
	}

	void Update () {
		if(button.ButtonClicked) {
      GameObject screen = Instantiate(Resources.Load("Screens/" + targetScreen.name)) as GameObject;
      screen.transform.parent = thisScreen.transform.parent.transform;
      Destroy(thisScreen);
		}
	}
}
