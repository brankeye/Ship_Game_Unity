using UnityEngine;
using System.Collections;

public class Toggle : MonoBehaviour {

	public Sprite activatedSprite, deactivatedSprite;
	
	private SpriteRenderer spriteRenderer;

	private bool toggleSelected = false;
  public bool ToggleSelected {
    get { return toggleSelected;  }
    set { toggleSelected = value; }
  }

	private bool toggleActive = false;
  public bool ToggleActive {
    get { return toggleActive;  }
    set { toggleActive = value; }
  }

  private bool toggleClicked = false;
  public bool ToggleClicked {
    get { return toggleClicked;  }
    set { toggleClicked = value; }
  }

	public GameObject mainCamera;
  private Camera camera;
	
	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		// need the camera to get screen point of raycast
		camera = mainCamera.GetComponent<Camera>();
	}

	void Update() {
		if(Input.touchCount > 0 || Input.GetMouseButton(0)) { // mobile: if there are any touches get the raycast of the first touch
      Vector2 rayPosition;
		  if(Input.touchCount > 0) {
				rayPosition = Input.touches[0].position;
			} else {
				rayPosition = Input.mousePosition;
			}
			Ray ray = camera.ScreenPointToRay(rayPosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

      toggleClicked = false;

			// if the user touched the button, change the button state accordingly
			if(hit != null && hit.collider != null) {
				Toggle theToggle = hit.collider.gameObject.GetComponent<Toggle>();
				if(theToggle != null && !theToggle.toggleActive) {
					theToggle.setToggle();
          theToggle.toggleActive = true;
          theToggle.toggleClicked = true;
				}
			}
		} else {
      toggleClicked = false;
      toggleActive = false;
    }
	}
	
	// change button state to down
	public void setToggle() {
		if(toggleSelected) {
			spriteRenderer.sprite = activatedSprite;
			toggleSelected = false;
		} else {
			spriteRenderer.sprite = deactivatedSprite;
			toggleSelected = true;
		}
	}
}
