using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showstatus : MonoBehaviour {
	string message="";
	int i=2;
	public Text board;
	// Use this for initialization
	void Start () {
		while (PlayerPrefs.HasKey ("clue" + i)) {
			message = message + "level " + (i-1) + " passed : " + PlayerPrefs.GetString ("clue" + i) + PlayerPrefs.GetString ("clue" + i + "_time") + '\n';
			i++;
		}
		if (PlayerPrefs.HasKey ("congrats")) {
			
			message = message + "Congrats on finishing , " + PlayerPrefs.GetString ("congrats") + PlayerPrefs.GetString ("congrats_time") + '\n';
		}
		board.text = message;
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
