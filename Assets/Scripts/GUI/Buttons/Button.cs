// Name: Button.cs
// Purpose: Handle the function of a button.

using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public Sprite inactiveSprite, activeSprite, disabledSprite;

  // to handle the changing of sprites based on button state
	private SpriteRenderer spriteRenderer;
  // track the state of the button
	private bool buttonDown = false;
	private bool activeButtonSprite = false;
  private GameObject mainCamera;
	private Camera theCamera;
  
	private bool buttonClicked = false;
	public bool ButtonClicked {
		get { return buttonClicked; }
	}

  private bool buttonActive = false;
  public bool ButtonActive {
    get { return buttonActive; }
    set { buttonActive = value; }
  }

  private bool buttonDisabled = false;
  public bool ButtonDisabled {
    get { return buttonDisabled; }
    set { buttonDisabled = value; }
  } 

	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = inactiveSprite;
		// need the camera to get screen point of raycast
    mainCamera = GameObject.FindWithTag("MainCamera");
		theCamera = mainCamera.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update() {
		// reset the button click
		buttonClicked = false;

    if(Input.touchCount > 0 || Input.GetMouseButton(0)) { // mobile: if there are any touches get the raycast of the first touch
		  Vector2 rayPosition;
			if(Input.touchCount > 0) {
				rayPosition = Input.touches[0].position;
			} else {
				rayPosition = Input.mousePosition;
			}
     
			Ray ray = theCamera.ScreenPointToRay(rayPosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

			// if the user touched the button, change the button state accordingly
			if(hit.collider != null) {
				Button theButton = hit.collider.gameObject.GetComponent<Button>();
        if(theButton != null && theButton.transform == gameObject.transform && !theButton.ButtonDisabled && !theButton.ButtonActive) {
					theButton.setButton(true);
          theButton.ButtonActive = true;
				}
			} else {
			  setButton(false); // button hasn't been touched but user still touching screen
        buttonActive = false;
			}
		} else {
			if(buttonDown) { // button was down before and has been released
				setButton(false); // set button to up state
				buttonClicked = true; // button has been clicked
			}
      buttonActive = false;
		}
	}

  // Function: disableButton()
  // Purpose: disable the button, make it unusable
  public void disableButton() {
    buttonDisabled = true;
    spriteRenderer.sprite = disabledSprite;
  }

  // Function: enableButton()
  // Purpose: enable the button, change the sprite
  public void enableButton() {
    buttonDisabled = false;
    spriteRenderer.sprite = inactiveSprite;
  }

  // Function: setButton(bool buttonActive)
	// Purpose: change button state
	public void setButton(bool buttonActive) {
    if (!activeButtonSprite && buttonActive) {
      activeButtonSprite = true;
      spriteRenderer.sprite = activeSprite;
    } else if (activeButtonSprite && !buttonActive) {
      activeButtonSprite = false;
      spriteRenderer.sprite = inactiveSprite;
    }

		buttonDown = buttonActive;
	}
}
