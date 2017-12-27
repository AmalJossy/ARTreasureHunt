using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConnectedLeverPuzzleLogic : MonoBehaviour
{
	public int numberLevers = 3;
	private bool[] toggled;
	LeverPull[] levers;

	public string nextscene;
	public string themessage;

	public void Toggle(int i)
	{
		if (i >= 0 && i < numberLevers)
		{
			toggled[i] = !toggled[i];
		}
	}
	
	public bool IsToggled(int i)
	{
		if (i >= 0 && i < numberLevers)
		{
			return toggled[i];
		}
		return false;
	}
	
	protected void Reset()
	{
		toggled = new bool[numberLevers];

		levers = GetComponentsInChildren<LeverPull>();
		for(int i = 0; i < levers.Length; i++)
		{
			levers[i].ForceUpPosition();
		}
	}
	
	protected bool CheckIfSolved()
	{
		bool solved = true;
		
		for (int i = 0; i < numberLevers; i++)
		{
			if (!toggled[i])
			{
				solved = false;
			}
		}
		
		return solved;
	}
	void Start(){
		Reset ();
	}
	void Update(){
		if (levers [0].IsMoving() && !(levers [1].IsMoving())) {
			levers [1].pullit();
		}
		if (levers [1].IsMoving() && !(levers [0].IsMoving()) && !(levers [2].IsMoving()) ) {
			levers [0].pullit();
			levers [2].pullit();
		}
		if (levers [2].IsMoving() && !(levers [1].IsMoving())) {
			levers [1].pullit();
		}
		if (CheckIfSolved () && !(levers [1].IsMoving()) && !(levers [0].IsMoving()) && !(levers [2].IsMoving())) {
			PlayerPrefs.SetString ("last", nextscene);
			PlayerPrefs.SetString (nextscene, themessage + " : ");
			updatetime ();
			PlayerPrefs.Save ();
			UnityEngine.SceneManagement.SceneManager.LoadScene (nextscene);
		}
	}
	void updatetime(){
		string str = nextscene + "_time";
		PlayerPrefs.SetString (str, System.DateTime.Now.ToString ());	

	}
}