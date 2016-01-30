using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public int Life = 5;

	public bool PlayerCarryingEarth = false;
	public bool PlayerCarryingWater = false;
	public bool PlayerCarryingFire = false;
	public bool PlayerCarryingAir = false;
	public bool PlayerCarryingEnergy = false;

	public bool AltarElementPresentEarth = false;
	public bool AltarElementPresentWater = false;
	public bool AltarElementPresentFire= false;
	public bool AltarElementPresentAir = false;
	public bool AltarElementPresentEnergy = false;

	public Transform Spawnpoint;

	#region Life Stuff
	public int GetLife() {
		return Life;
	}

	#endregion

	void Start() {
		Invoke ("TriggerLifeChangedEvent", 1f);
		Grid.EventHub.RunOverElement += HandleElementPickup;
	}

	private void TriggerLifeChangedEvent() {
		Grid.EventHub.TriggerLifePowerChanged (GetLife());
	}


	private void HandleElementPickup(GameObject element) {
		if (element.name == "Erde") {
			PlayerCarryingEarth = true;
		}
		if (element.name == "Wasser") {
			PlayerCarryingWater = true;
		}
		if (element.name == "Feuer") {
			PlayerCarryingFire = true;
		}
		if (element.name == "Luft") {
			PlayerCarryingAir = true;
		}
		if (element.name == "Energie") {
			PlayerCarryingEnergy = true;
		}
	}

	void OnDestroy() {
		Grid.EventHub.RunOverElement -= HandleElementPickup;

	}

}
