using UnityEngine;
using System.Collections;

public class SwitchScreens : MonoBehaviour {
	
	public GameObject targetScreen;
	private Button button;

	void Start () {
		button = GetComponent<Button> ();
	}

	void Update () {
		if(button.ButtonClicked) {
			// move target screen to front
			targetScreen.transform.position = new Vector3(targetScreen.transform.position.x,
			                                              targetScreen.transform.position.y,
			                                              targetScreen.transform.position.z - 1);
			// move current screen to back
			transform.parent.position = new Vector3(transform.parent.position.x,
			                              transform.parent.position.y,
			                              transform.parent.position.z + 1);
		}
	}
}
