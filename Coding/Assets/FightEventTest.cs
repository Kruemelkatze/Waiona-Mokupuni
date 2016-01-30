using UnityEngine;
using System.Collections;

public class FightEventTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject != Grid.Player)
			return;

		Debug.Log ("Start fight");
		Grid.EventHub.TriggerEnemyStartFight (transform.gameObject);
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject != Grid.Player)
			return;

		Debug.Log ("Fight won");
		Grid.EventHub.TriggerFightWin (transform.gameObject);
	}
}
