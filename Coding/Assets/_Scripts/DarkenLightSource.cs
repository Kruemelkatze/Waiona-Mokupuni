using UnityEngine;
using System.Collections;

public class DarkenLightSource : MonoBehaviour {

	public float defaultIntensity = 1;
	public float dimmedIntensity = 0.5f;

	void OnTriggerEnter(Collider other) {
		if(other.gameObject != Grid.Player) {
			return;
		}

		Grid.DirectionalLight.intensity = dimmedIntensity;
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject != Grid.Player) {
			return;
		}
		Grid.DirectionalLight.intensity = defaultIntensity;
	}
}
