using UnityEngine;
using System.Collections;

public class FightControl : MonoBehaviour {

	public AudioClip Chord1;
	public AudioClip Chord2;
	public AudioClip Chord3;
	public AudioClip Chord4;


	public enum FightState
	{
		Idle,
		WaitForPlayerInput,
		WrongButtonPlayed,

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame 	
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			PlayChord1 ();
		}
		if(Input.GetButtonDown("Fire2")) {
			PlayChord2 ();
		}
		if(Input.GetButtonDown("Fire3")) {
			PlayChord3 ();
		}
		if(Input.GetButtonDown("Jump")) {
			PlayChord4 ();
		}
	}

	private void PlayChord1() {
		Grid.SoundManager.PlaySingle (Chord1);
	}
	private void PlayChord2() {
		Grid.SoundManager.PlaySingle (Chord2);
	}
	private void PlayChord3() {
		Grid.SoundManager.PlaySingle (Chord3);
	}
	private void PlayChord4() {
		Grid.SoundManager.PlaySingle (Chord4);
	}



}
