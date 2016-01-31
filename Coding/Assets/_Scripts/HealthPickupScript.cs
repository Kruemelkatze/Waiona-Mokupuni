using UnityEngine;
using System.Collections;

public class HealthPickupScript : MonoBehaviour {
	public AudioClip PickupSound;
	public int healthValue = 1;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject != Grid.Player || (healthValue > 0 && Grid.GameLogic.CurrentLife == Grid.GameLogic.MaxLife)) {
			return;
		}

		Grid.EventHub.TriggerLifeChanged (healthValue);
		Grid.SoundManager.PlaySingle (PickupSound, 1);
		Destroy (gameObject);
	}
}
