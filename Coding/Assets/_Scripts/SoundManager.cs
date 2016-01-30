using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioSource[] efxSource;
	public AudioSource musicSource;
	public AudioSource loopMusic;

	public AudioClip defaultTheme;
	public float defaultThemeVolume = 1;

	public AudioClip fightTheme;
	public float fightThemeVolume = 0.3f;

	public AudioClip currentTheme;
	public float currentThemeVolume = 1;

	private int nextSourceToUse = 0;
	public float lowPitchRange = .95f;
	public float highPitchRange = 1.05f;

	void Awake(){
		currentTheme = defaultTheme;
		PlayCurrentTheme ();

		Grid.EventHub.EnemyStartFight += OnEnemyStartFight;
		Grid.EventHub.FightLoose += OnFightLoose;
		Grid.EventHub.FightWin += OnFightWin;
	}

	void OnDestroy() {
		Grid.EventHub.EnemyStartFight -= OnEnemyStartFight;
		Grid.EventHub.FightLoose -= OnFightLoose;
		Grid.EventHub.FightWin -= OnFightWin;
	}

	public void PlaySingle(AudioClip clip, float volume = 1)
	{
		int index = nextSourceToUse;
		nextSourceToUse = (nextSourceToUse + 1) % efxSource.Length;
		efxSource [index].clip = clip;
		efxSource [index].volume = volume;
		efxSource [index].Play ();
	}

	public void RandomizeSfx (float volume, params AudioClip[] clips)
	{
		if (volume < 0) {
			volume = 0;
		} else if (volume > 1) {
			volume = 1;
		}
		int randomIndex = Random.Range(0, clips.Length);

		float randomPitch = Random.Range(lowPitchRange, highPitchRange);

		int index = nextSourceToUse;
		nextSourceToUse = (nextSourceToUse + 1) % efxSource.Length;

		efxSource[index].pitch = randomPitch;

		efxSource[index].clip = clips[randomIndex];
		efxSource [index].volume = volume;
		efxSource[index].Play();
	}

	//Event Handlers
	public void OnFightLoose() {
		PlayCurrentTheme ();
	}

	public void OnFightWin(GameObject unused) {
		PlayCurrentTheme ();
	}

	public void OnEnemyStartFight(GameObject unused) {
		PlayFightTheme ();
	}

	//Music controller

	public void SetCurrentTheme(AudioClip clip, float volume = 1) {
		bool sameTheme = clip.name.Equals (currentTheme.name);

		currentTheme = clip;
		currentThemeVolume = volume;

		if (loopMusic.clip != fightTheme && !sameTheme) {
			PlayCurrentTheme ();
		}
	}

	public void SetDefaultThemeAsCurrentTheme() {
		SetCurrentTheme (defaultTheme, defaultThemeVolume);
	}

	public void PlayCurrentTheme() {
		PlayMusic (currentTheme, currentThemeVolume);
	}

	public void PlayFightTheme() {
		PlayMusic (fightTheme, fightThemeVolume);
	}

	public void PlayMusic(AudioClip clip, float volume = 1) {
		loopMusic.Stop ();
		loopMusic.loop = true;
		loopMusic.clip = clip;
		loopMusic.volume = volume;
		loopMusic.Play ();
	}
}
