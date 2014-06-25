

using UnityEngine;
using System.Collections;

public class ChangeScenes : MonoBehaviour {

	public string scene;
	private Button playButton;
	
	void Start () {
		playButton = GetComponent<Button>();
	}

	void Update () {
		if(playButton.ButtonClicked) {
			Application.LoadLevel(scene);
		}
	}
}
