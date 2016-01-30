using UnityEngine;
using System.Collections;

public class ElementPickup : MonoBehaviour {

	public AudioSource PickupSound;

	void OnCollisionEnter(Collision collision) {
		Grid.EventHub.TriggerRunOverElement (collision.other.gameObject);
		PickupSound.Play ();
	}
}
