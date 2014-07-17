using UnityEngine;
using System.Collections;

public class RotateTool : MonoBehaviour {

  private float currentRotation;
  private float rotationAngle;

  public float CurrentRotation {
    get { return currentRotation; }
  }

	void Start () {
    rotationAngle = 90.0f;
    currentRotation = 0.0f;
	}

  public void SetBlockRotation() {
    float newAngle = currentRotation + rotationAngle;
    if(newAngle > 360.0f) {
      newAngle = 0.0f;
    }
    currentRotation = newAngle;
    Debug.Log(currentRotation);
  }
}
