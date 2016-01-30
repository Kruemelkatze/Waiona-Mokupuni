using UnityEngine;
using System.Collections;

public class MusicAreaScript : MonoBehaviour {

	public AudioClip customTheme;
	public float customThemeVolume = 1f;

	void OnTriggerEnter(Collider other) {
		if(other.gameObject != Grid.Player || customTheme == null) {
			return;
		}

		Debug.Log ("Entered Area");

		Grid.SoundManager.SetCurrentTheme (customTheme, customThemeVolume);

	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject != Grid.Player) {
			return;
		}
		Debug.Log ("Exited Area");
		Grid.SoundManager.SetDefaultThemeAsCurrentTheme ();
	}
}
