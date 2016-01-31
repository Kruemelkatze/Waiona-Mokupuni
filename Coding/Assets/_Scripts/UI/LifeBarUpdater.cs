using UnityEngine;
using System.Collections;

public class LifeBarUpdater : MonoBehaviour {

	private bool initialized = false;

	public GameObject[] Flowers;
	private Animator[] FlowerAnimators = new Animator[5];
	public int lastLifeValue;

	void Start() {
		lastLifeValue = Grid.GameLogic.MaxLife;
	}

	void Awake() {
		Grid.EventHub.LifeChangedUpdater += UpdateLifeBar;
		for (int i = 0; i < Flowers.Length; i++) {
			FlowerAnimators [i] = Flowers[i].GetComponent<Animator>();
			FlowerAnimators [i].SetTrigger ("FlowerBloom");
		}
		initialized = true;
	}

	public void UpdateLifeBar(int lifePoints) {
		if (!initialized) {
			Debug.LogError ("Tried to execute lifechanged event, before lifemanager initialized");
			return;
		}

		if (lifePoints >= 0 && lifePoints < lastLifeValue) {
			for (int i = lifePoints; i <  lastLifeValue; i++) {
				FlowerAnimators [i].SetTrigger("FlowerShrink");
			}
		} else if (lifePoints <= Flowers.Length && lifePoints > lastLifeValue){
			if (lastLifeValue < 0)
				lastLifeValue = 0;
			for (int i = lastLifeValue; i < lifePoints; i++) {
				FlowerAnimators [i].SetTrigger("FlowerBloom");
			}
		}
		lastLifeValue = lifePoints;
	}

	void OnDestroy() {
		Grid.EventHub.LifeChanged -= UpdateLifeBar;
	}

}
