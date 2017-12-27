using UnityEngine;
using System.Collections;

public class playerprefstream : MonoBehaviour {
	string lastscene;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("started")) {
			lastscene = PlayerPrefs.GetString ("last");
		}
		else{
			lastscene = "story";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			Application.Quit();
		}
	}
	public void gamestart(){
		if (!PlayerPrefs.HasKey ("started")) {
			PlayerPrefs.SetString ("started", "true");
			PlayerPrefs.SetString ("last", "story");
		}
		PlayerPrefs.Save();
		UnityEngine.SceneManagement.SceneManager.LoadScene (lastscene);
	}
}
