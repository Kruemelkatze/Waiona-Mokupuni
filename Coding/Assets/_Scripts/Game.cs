using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public int Life = 5;


	public Transform Spawnpoint;

	#region Life Stuff
	public int GetLife() {
		return Life;
	}

	#endregion

	void Start() {
		Invoke ("TriggerLifeChangedEvent", 1f);
	}

	private void TriggerLifeChangedEvent() {
		Grid.EventHub.TriggerLifePowerChanged (GetLife());
	}

}
