using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour {

	

	public void OnPlayClick() {
		Invoke("LoadStory", 0.5f);
	}



	public static void OnExitClick() {
		Application.Quit ();
	}

	private void LoadStory() {
		SceneManager.LoadScene ("Story");
	}


}
