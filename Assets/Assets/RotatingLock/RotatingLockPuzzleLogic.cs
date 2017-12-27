using UnityEngine;
using System.Collections.Generic;


public class RotatingLockPuzzleLogic : MonoBehaviour {

    public List<float> solution = new List<float> {180.0f, 90.0f, 0.0f};
	public string nextscene;
	public string themessage;

    public List<GameObject> cylinders;

    private bool solvedOuter;
    private bool solvedInner;
    private bool solvedMiddle;

	protected void Reset()
	{
		solvedOuter = false;
		solvedInner = false;
		solvedMiddle = false;

		foreach (GameObject cylinder in cylinders)
		{
			cylinder.transform.localEulerAngles = new Vector3(0, 0, 0);
		}
	}


    protected bool CheckIfSolved1()
    {
            Vector3 gravity = Sensors.Gravity();
			Vector3 projectedGravity = Vector3.ProjectOnPlane(gravity,Vector3.forward);
            projectedGravity.Normalize();
            
            float angle = Vector3.Angle(-Vector3.up, projectedGravity);
            float sign = Mathf.Sign(Vector3.Dot(projectedGravity, Vector3.right));
            angle = sign * angle;
            angle = angle - 360.0f * Mathf.Floor(angle / 360.0f);


            
            if (!solvedOuter)
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject cylinder = cylinders[i];
					cylinder.transform.localEulerAngles = new Vector3(0, 0, angle);
                }
                
                float goalAngle = solution[0];
                if (Mathf.Abs(goalAngle - angle) < 4.0f)
                {
                    solvedOuter = true;
                    GameObject outer = cylinders[0];
					outer.transform.localEulerAngles = new Vector3(0, 0, goalAngle);
                }
            }
            else if (!solvedMiddle)
            {
                for (int i = 1; i < 3; i++)
                {
                    GameObject cylinder = cylinders[i];
                    cylinder.transform.localEulerAngles = new Vector3(0, 0, angle);
                }
                
                float goalAngle = solution[1];
                if (Mathf.Abs(goalAngle - angle) < 4.0f)
                {
                    solvedMiddle = true;
                    GameObject middle = cylinders[1];
                    middle.transform.localEulerAngles = new Vector3(0, 0, goalAngle);
                }
            }
            else if (!solvedInner)
            {
                for (int i = 2; i < 3; i++)
                {
                    GameObject cylinder = cylinders[i];
					cylinder.transform.localEulerAngles = new Vector3(0, 0, angle);
                }
                
                float goalAngle = solution[2];
                if (Mathf.Abs(goalAngle - angle) < 4.0f)
                {
                    solvedInner = true;
                    GameObject inner = cylinders[2];
					inner.transform.localEulerAngles = new Vector3(0, 0, goalAngle);
                }
            }
        

        return (solvedInner && solvedMiddle && solvedOuter);
    }
    
    void Awake()
	{	
        if (cylinders.Count != 3)
        {
            Debug.LogError("Connect cylinders in the RotatingLock puzzle.");
        }
        if (solution.Count != 3)
        {
			Debug.LogError("RotatingLock puzzle solution expects 3 values.");
        }
		Reset ();
    }

	void Update(){
		if (CheckIfSolved1 ()) {
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