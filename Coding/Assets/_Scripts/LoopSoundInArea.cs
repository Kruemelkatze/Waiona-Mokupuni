using UnityEngine;
using System.Collections;

public class LoopSoundInArea : MonoBehaviour {

	public AudioSource source;
	public float delay = 0;

	public bool inArea = false;

	// Use this for initialization
	void Start () {
		source.loop = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (inArea && !source.isPlaying) {
			source.PlayDelayed (delay);
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject != Grid.Player) {
			return;
		}
		source.Play ();
		inArea = true;
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject != Grid.Player) {
			return;
		}
		source.Stop ();
		inArea = false;
	}
}
