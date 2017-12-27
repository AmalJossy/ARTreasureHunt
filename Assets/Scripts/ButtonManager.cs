using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void NewGameButton(string startAR){
		SceneManager.LoadScene(startAR);

	}
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
