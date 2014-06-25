using UnityEngine;
using System.Collections;

public class MoveObjectWithMouse : MonoBehaviour {

    // the power with which the ship is launched initially
	public GameObject lineRenderer;
    public float      launchPower = 1.0f;

    private Vector2  firstMouseWorldSpace, finalMouseWorldSpace;
    private bool     mouseDown = false;
    private bool     mouseUp   = false;
    private DrawLine drawLineScript;

    // the direction to launch the ship in (is not normalized, so also counts as a force)
    private Vector2 launchForce;
	
    void Start() {
        drawLineScript = lineRenderer.GetComponent<DrawLine>();
    }

	void Update () {
        // if the player left clicked, find the position at the click
        if(!mouseDown && Input.GetMouseButtonDown(0)) {
            firstMouseWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseDown = true;
        }

        // if the player released the click, find the position at the release
        if(mouseDown) {
            if(!mouseUp && Input.GetMouseButtonUp(0)) {
                finalMouseWorldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseUp = true;

                // calculate the launch force using each mouse space (first click minus second click)
                // this will launch the ship in the opposite direction of the dragging of the mouse
                launchForce = firstMouseWorldSpace - finalMouseWorldSpace;
            }

            // draw a line from the first position at click to the current mouse position
            drawLineScript.drawLine(firstMouseWorldSpace, 
                                    Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
	}

    void FixedUpdate() {
        // if the player released the mouse, launch the ship
        if(mouseUp) {
            rigidbody2D.AddForce(launchForce * launchPower);
            reset();
            /*
            MoveObjectWithMouse moveObjectWithMouseScript = GetComponent<MoveObjectWithMouse>();
            moveObjectWithMouseScript.enabled = false;
            */
        }
    }

    void reset() {
        mouseDown = false;
        mouseUp = false;
    }
}
