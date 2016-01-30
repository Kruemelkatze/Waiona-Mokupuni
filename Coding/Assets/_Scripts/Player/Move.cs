using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {


	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;



	private CharacterController cController;
	private Vector3 forceVector;
	private Animator animatorC;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		cController = GetComponent<CharacterController> ();
		animatorC = GetComponent<Animator> ();
		spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
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

		UpdateAnimation ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void UpdateAnimation() {
		var verticalForce = Input.GetAxisRaw ("Vertical");
		var horizontalForce = Input.GetAxisRaw ("Horizontal");

		if (verticalForce == 0 && horizontalForce == 0) {
			animatorC.SetTrigger ("Idle");
		}

		if (verticalForce > 0) {
			animatorC.SetTrigger ("Upwards");
		} 
		if (verticalForce < 0) {
			animatorC.SetTrigger ("Walking");
		}
		if (horizontalForce > 0) {
			spriteRenderer.flipX = false;
		}
			
		if (horizontalForce < 0) {
			spriteRenderer.flipX = true;
		}

	}

}
