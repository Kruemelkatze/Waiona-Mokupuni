using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Follow : MonoBehaviour {

	// reference to object that should be followed
	public GameObject ObjectToFollow;
	// y offset to Player
	public float XOffset = 0;
	public float YOffset = 0;
	public float ZOffset = 0;

	public bool FollowX = true;
	public bool FollowY = true;
	public bool FollowZ = true;

	public float LerpDelta = 1f;
	public bool UseLerp = false;

	public bool Following = true;

	// Use this for initialization
	void Start () {
		if (ObjectToFollow == null) {
			// Not sooo bad.
			Debug.LogError("No Follow Object set!!!! " + gameObject.name);
		}


	}

	void HandleFinishedParcour ()
	{
//		FollowOff();
	}
	
	// Update is called once per frame
	void Update () {
		if(!Following) return;

		if (ObjectToFollow == null)
			return;
		// position of the object that is following
		var sourcePosition = transform.position;
		// get position of the follow object
		var targetPosition = ObjectToFollow.transform.position;
		// calculate the offsets
		targetPosition.x += XOffset;
		targetPosition.y += YOffset;
		targetPosition.z += ZOffset;

		// copy position values only if we follow them
		if(UseLerp) {
			if(FollowX) sourcePosition.x = Mathf.Lerp(sourcePosition.x, targetPosition.x, LerpDelta * Time.smoothDeltaTime);
			if(FollowY) sourcePosition.y = Mathf.Lerp(sourcePosition.y, targetPosition.y, LerpDelta * Time.smoothDeltaTime);
			if(FollowZ) sourcePosition.z = Mathf.Lerp(sourcePosition.z, targetPosition.z, LerpDelta * Time.smoothDeltaTime);
		} else {
			if(FollowX) sourcePosition.x = targetPosition.x;
			if(FollowY) sourcePosition.y = targetPosition.y;
			if(FollowZ) sourcePosition.z = targetPosition.z;
		}


		// set the new position to the following object
		transform.position = sourcePosition;
	}

	public void FollowOn() {
		Following = true;
	}

	private void FollowOff() {
		Following = false;
	}

}
