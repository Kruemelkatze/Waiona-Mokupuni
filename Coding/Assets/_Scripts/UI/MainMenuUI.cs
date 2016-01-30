using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour {

	

	public void OnPlayClick() {
		SceneManager.LoadScene ("Story");
	}



	public static void OnExitClick() {
		Application.Quit ();
	}



}
