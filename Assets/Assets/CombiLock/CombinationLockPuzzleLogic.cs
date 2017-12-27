using UnityEngine;
using System.Collections.Generic;

public class CombinationLockPuzzleLogic : MonoBehaviour {

    public List<int> combination = new List<int> {3, 5, 8, 7};
	public string nextscene;
	public string themessage;

	public List<GameObject> dialGameObjects;
    CombinationLockDial[] dials;


    public bool CheckIfSolved()
    {
        bool solved = true;

        for (int i = 0; i < dials.Length; i++)
        {
            if (dials[i].GetDigit() != combination[i])
            {
                solved = false;
            }
        }

        return solved;
    }


    void Awake()
    {
		if (dialGameObjects.Count != 4)
		{
			Debug.LogError("Connect cylinders in the CombinationLock puzzle.");
		}
		dials = new CombinationLockDial[4];
		int i = 0;
		foreach (GameObject go in dialGameObjects)
		{
			CombinationLockDial dial = go.GetComponent<CombinationLockDial>();
			dials[i] = dial;
			i++;
		}
        if (combination.Count != dials.Length)
        {
            Debug.LogError("Number of Digit Dials in the Combination Lock doesn't match the combination.");
        }
    }
	void Start(){
		foreach (CombinationLockDial dial in dials)
		{
			dial.SetDigit(0);
		}
	}
	public void validatelock(){
		if (CheckIfSolved ()) {
			PlayerPrefs.SetString ("last", nextscene);
			PlayerPrefs.SetString (nextscene, themessage + " : ");
			updatetime ();
			PlayerPrefs.Save ();
			UnityEngine.SceneManagement.SceneManager.LoadScene (nextscene);

		}
	}
	void updatetime(){
		string str=nextscene+"_time";
		PlayerPrefs.SetString (str, System.DateTime.Now.ToString());	
	}
	

}