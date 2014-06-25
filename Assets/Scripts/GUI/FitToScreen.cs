using UnityEngine;
using System.Collections;

public class FitToScreen : MonoBehaviour {

	private Camera mainCamera;
	private float height, width, distance;

	void Start () {
		mainCamera = GameObject.Find ("Main Camera").GetComponent<Camera>();

		distance = transform.position.z - mainCamera.transform.position.z;
		height = 2.0f * Mathf.Tan(0.5f * mainCamera.fieldOfView * Mathf.Deg2Rad) * distance;
		width = height * Screen.height / Screen.width;

		transform.localScale = new Vector2(width, height);
	}

	void Update () {

	}
}
