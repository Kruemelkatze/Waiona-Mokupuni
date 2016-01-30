using UnityEngine;
using System.Collections;

public class ElementPickup : MonoBehaviour {

	public AudioClip PickupSound;

	void OnTriggerEnter(Collider other) {
		Grid.EventHub.TriggerRunOverElement (other.gameObject);
		Grid.SoundManager.PlaySingle (PickupSound, 1);
		Destroy (gameObject);
	}
}
