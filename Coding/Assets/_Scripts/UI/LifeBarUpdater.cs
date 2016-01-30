using UnityEngine;
using System.Collections;

public class LifeBarUpdater : MonoBehaviour {


	void Start() {
		Grid.EventHub.LifeChanged += LifePowerChanged;
	}

	public void LifePowerChanged(int lifePoints) {

	}

	

}
