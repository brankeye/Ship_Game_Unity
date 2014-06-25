using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {
	public float speed = 0;
	// object that controls the speed of the moving background
	public GameObject controllingObject;
	private Rigidbody2D objectRigidbody;
	private Vector2 texturePosition = Vector2.zero;

	// Use this for initialization
	void Start () {
		objectRigidbody = controllingObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		texturePosition += new Vector2(objectRigidbody.velocity.x / speed, objectRigidbody.velocity.y / speed);

		renderer.material.mainTextureOffset = texturePosition;
	}
}
