using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {

	public float speed = 3f;
	public float jumpSpeed = 10f;
	public float gravity = 20f;

	//function for rotating
	public void Rotating ( float Degrees ) {
			transform.Rotate (0f, Degrees, 0f);
		}
	

	// Update is called once per frame
	void Update () {
		//momentum is set to 0 every frame
		Vector3 moveDirection = Vector3.zero;

		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded) {
			//spacebar jumps up
			if (Input.GetKey(KeyCode.Space))
				moveDirection += transform.up*jumpSpeed;
				}

		//moves forward/back if W/S are pressed
		if (Input.GetKey(KeyCode.W))
			moveDirection = transform.forward*speed;

		if (Input.GetKey(KeyCode.S))
			moveDirection = -transform.forward*speed;
		//rotates if A/D are pressed
		if (Input.GetKey (KeyCode.A)) {
			Rotating (5f);
				}
		if (Input.GetKey (KeyCode.D)) {
			Rotating (-5f);
				}
		//character is pulled down by gravity over time
		moveDirection.y -= gravity;

		controller.Move(moveDirection * Time.deltaTime);
	}
}
