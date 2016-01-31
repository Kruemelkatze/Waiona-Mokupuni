using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinButtonBackToTitle : MonoBehaviour {

	public void BackToTitle() {
		SceneManager.LoadScene ("Title");
	}
}
