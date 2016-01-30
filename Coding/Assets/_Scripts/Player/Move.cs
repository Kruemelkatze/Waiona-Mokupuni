using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {


	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;



	private CharacterController cController;
	private Vector3 forceVector;

	// Use this for initialization
	void Start () {
		cController = GetComponent<CharacterController> ();
	}

	void FixedUpdate() {


		//if (cController.isGrounded) {

			var verticalForce = Input.GetAxisRaw ("Vertical");
			var horizontalForce = Input.GetAxisRaw ("Horizontal");
			forceVector = new Vector3 (horizontalForce, 0, verticalForce);

			// this would let the player run in the direction where he is looking
			//forceVector = transform.TransformDirection(forceVector);
			forceVector *= speed;
			if (Input.GetButton("Jump"))
				forceVector.y = jumpSpeed;
			
		//}
		forceVector.y -= gravity * Time.deltaTime;
		cController.Move(forceVector * Time.deltaTime);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
