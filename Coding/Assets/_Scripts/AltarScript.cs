using UnityEngine;
using System.Collections;



public class AltarScript : MonoBehaviour {

	public Element correspondingElement;
	public GameObject WaterPrefab;
	public GameObject AirPrefab;
	public GameObject FirePrefab;
	public GameObject EarthPrefab;
	public GameObject EnergyPrefab;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if(other.gameObject != Grid.Player) {
			return;
		}

		Debug.Log ("Altar: " + correspondingElement);

		switch (correspondingElement) {
			case Element.Fire:
				if (Grid.GameLogic.PlayerCarryingFire) {
					Debug.Log (correspondingElement + " inserted");
					
					Grid.EventHub.TriggerSaveInAltar (new GameObject{ name = "Feuer" });
					CreateInstance (FirePrefab);
				}
				break;
			case Element.Air:
				if (Grid.GameLogic.PlayerCarryingAir) {
					Debug.Log (correspondingElement + " inserted");
					
					Grid.EventHub.TriggerSaveInAltar (new GameObject{ name = "Luft" });
					CreateInstance (AirPrefab);
				}
				break;
			case Element.Water:
				if (Grid.GameLogic.PlayerCarryingWater) {
					Debug.Log (correspondingElement + " inserted");
					
					Grid.EventHub.TriggerSaveInAltar (new GameObject{ name = "Wasser" });
					CreateInstance (WaterPrefab);
				}
				break;
			case Element.Earth:
				if (Grid.GameLogic.PlayerCarryingEarth) {
					Debug.Log (correspondingElement + " inserted");
					
					Grid.EventHub.TriggerSaveInAltar (new GameObject{ name = "Erde" });
					CreateInstance (EarthPrefab);
				}
				break;
			case Element.Energy:
				if (Grid.GameLogic.PlayerCarryingEnergy) {
					Debug.Log (correspondingElement + " inserted");
					
					Grid.EventHub.TriggerSaveInAltar (new GameObject{ name = "Energie" });
					CreateInstance (EnergyPrefab);
				}
				break;
		}
	}

	private void CreateInstance(GameObject prefab) {
		GameObject instance = Instantiate(prefab);
		instance.transform.parent = transform;
		instance.transform.localPosition = new Vector3(0, 0.8f, 0);
		instance.transform.localScale = new Vector3(1, 0.5f, 1);

		BoxCollider collider = instance.GetComponent<BoxCollider>();
		if (collider != null) {
			Destroy (collider);
		}

	}


}

public enum Element {
	Fire, Water, Air, Earth, Energy
}