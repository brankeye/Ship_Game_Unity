// Name: Button.cs
// Purpose: Handle the function of a button.

using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public Sprite inactiveSprite, activeSprite;

	private SpriteRenderer spriteRenderer;
	private bool buttonDown = false;
	private bool activeButtonSprite = false;
	private Camera mainCamera;

	private bool buttonClicked = false;
	public bool ButtonClicked {
		get { return buttonClicked; }
	}

	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = inactiveSprite;
		// need the camera to get screen point of raycast
		mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update() {
		// reset the button click
		buttonClicked = false;

		if(transform.parent.position.z == 0.0f) {
			if(Input.touchCount > 0 || Input.GetMouseButton(0)) { // mobile: if there are any touches get the raycast of the first touch
				Vector2 rayPosition;
				if(Input.touchCount > 0) {
					rayPosition = Input.touches[0].position;
				} else {
					rayPosition = Input.mousePosition;
				}

				Ray ray = mainCamera.ScreenPointToRay(rayPosition);
				RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

				// if the user touched the button, change the button state accordingly
				if(hit != null && hit.collider != null) {
					Button theButton = hit.collider.gameObject.GetComponent<Button>();
					if(theButton != null) {
						theButton.setButton(true);
					}
				} else {
					setButton(false); // button hasn't been touched but user still touching screen
				}
			} else {
				if(buttonDown) { // button was down before and has been released
					setButton(false); // set button to up state
					buttonClicked = true; // button has been clicked
				}
			}
		}
	}

	// change button state to down
	public void setButton(bool buttonActive) {
		if(!activeButtonSprite && buttonActive) {
			activeButtonSprite = true;
			spriteRenderer.sprite = activeSprite;
		} else if(activeButtonSprite && !buttonActive) {
			activeButtonSprite = false;
			spriteRenderer.sprite = inactiveSprite;
		}

		buttonDown = buttonActive;
	}
}
