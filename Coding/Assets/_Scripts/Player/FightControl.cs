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
	
	}
}
