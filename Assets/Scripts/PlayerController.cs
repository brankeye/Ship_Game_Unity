using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 0;
	public float amountOfDrag = 0;
	private float horizontalMovement, verticalMovement;
	private float horizontalForce, verticalForce;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		horizontalMovement = Input.GetAxis("Jump");
		verticalMovement = Input.GetAxis("Vertical");

		horizontalForce = horizontalMovement * speed;
		verticalForce   = verticalMovement * speed;

		rigidbody2D.drag = rigidbody2D.velocity.magnitude * amountOfDrag;
	}

	void FixedUpdate() {
		// horizontal force
		rigidbody2D.AddRelativeForce(Vector2.right * horizontalForce);
		// vertical force
		rigidbody2D.AddRelativeForce(Vector2.up * verticalForce);
	}
}
