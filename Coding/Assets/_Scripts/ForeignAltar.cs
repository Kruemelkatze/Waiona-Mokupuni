using UnityEngine;
using System.Collections;

public class ForeignAltar : MonoBehaviour {

	private GameObject elementPickup;

	// Use this for initialization
	void Start () {
		foreach(Transform child in transform) {
			if(child.gameObject.tag.Equals("ElementPickup")) {
				elementPickup = child.gameObject;
				break;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other != Grid.Player) {
			return;
		}
		Grid.EventHub.TriggerRunOverElement (elementPickup);
	}
}
