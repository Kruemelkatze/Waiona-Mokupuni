using UnityEngine;
using System.Collections;

public class ElementPickup : MonoBehaviour {

	public AudioClip PickupSound;
	public Element element;

	void OnTriggerEnter(Collider other) {
		Grid.EventHub.TriggerRunOverElement (gameObject);
		Grid.SoundManager.PlaySingle (PickupSound, 1);
		Destroy (gameObject);
	}
}
