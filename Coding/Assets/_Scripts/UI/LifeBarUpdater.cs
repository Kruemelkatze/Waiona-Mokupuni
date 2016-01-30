using UnityEngine;
using System.Collections;

public class LifeBarUpdater : MonoBehaviour {

	private bool initialized = false;

	public GameObject[] Flowers;
	private Animator[] FlowerAnimators = new Animator[5];

	private int lastLifePower = 0;



	void Awake() {
		Grid.EventHub.LifeChanged += LifePowerChanged;
		for (int i = 0; i < Flowers.Length; i++) {
			FlowerAnimators [i] = Flowers[i].GetComponent<Animator>();
		}
		initialized = true;
	}

	void Start() {
		
		lastLifePower = Grid.GameLogic.GetLife ();

	}

	public void LifePowerChanged(int lifePoints) {
		if (!initialized) {
			Debug.LogError ("Tried to execute lifechanged event, before lifemanager initialized");
			return;
		}
		for (int i = 0; i < Flowers.Length; i++) {
			FlowerAnimators [i].SetTrigger(i < lifePoints ? "FlowerBloom" : "FlowerShrink");
		}
		lastLifePower = lifePoints;
	}

	void OnDestroy() {
		Grid.EventHub.LifeChanged -= LifePowerChanged;
	}

}
