using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioSource[] efxSource;
	public AudioSource musicSource;
	public AudioSource loopMusic;
	private int nextSourceToUse = 0;
	public float lowPitchRange = .95f;
	public float highPitchRange = 1.05f;

	void Awake(){
		//musicSource.Play ();

		//loopMusic.PlayDelayed (musicSource.clip.length);
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
}
