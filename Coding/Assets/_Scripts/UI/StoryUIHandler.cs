using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StoryUIHandler : MonoBehaviour {

	public void OnPlayClick() {
		SceneManager.LoadScene ("Level1");
	}
}
