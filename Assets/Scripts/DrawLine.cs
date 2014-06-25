using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {

    private LineRenderer lineRenderer;
    private float distance;
    private Vector2 origin, destination;
    private bool drawTheLine = false;

	// Use this for initialization
	void Start () { 
        lineRenderer = GetComponent<LineRenderer>();

        // draw the line on top
        lineRenderer.sortingOrder = 10;
	}
	
	// Update is called once per frame
	void Update () {
        // draw the line using data received from the drawLine() function
	    if (drawTheLine) {
            // set the position of the origin and destination points in the line renderer
            lineRenderer.SetPosition(0, origin);
            lineRenderer.SetPosition(1, destination);
            // change the color from yellow to red based on the distance between the origin and destination
            Color newColor = Color.yellow;
            newColor.g -= distance / 10.0f;
            lineRenderer.SetColors(newColor, newColor);

            // stop drawing the line
            drawTheLine = false;
        } else {
            lineRenderer.SetPosition(1, origin);
        }
	}

    // function to be called from other objects to draw a line based on two input parameters
    public void drawLine(Vector2 originTemp, Vector2 destinationTemp) {
        // save the origin and destination
        origin = originTemp;
        destination = destinationTemp;

        // determine the distance between the origin and destination
        distance = Vector2.Distance(origin, destination);

        // draw the line in the Update() function
        drawTheLine = true;
    }
}
