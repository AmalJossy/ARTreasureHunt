using UnityEngine;
using System.Collections;


public class ButtonClick : MonoBehaviour {
	public string nextscene;
	public string themessage;

	// Use this for initialization

	void OnMouseDown() {
		PlayerPrefs.SetString ("last", nextscene);
		PlayerPrefs.SetString (nextscene, themessage+ " : ");
		updatetime ();
		PlayerPrefs.Save ();
		UnityEngine.SceneManagement.SceneManager.LoadScene (nextscene);
		
	}
	void updatetime(){
		string str=nextscene+"_time";
		PlayerPrefs.SetString (str, System.DateTime.Now.ToString());	
	
	}

}
