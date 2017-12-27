using UnityEngine;
using System.Collections;

public abstract class LeverAction : MonoBehaviour
{
	#region Fields
	
	protected LeverPull leverScript;
	private bool performedAction;
	
	#endregion
	
	#region Mandatory To Implement
	
	abstract protected void Action();
	
	#endregion
	
	#region Optional To Implement
	
	virtual protected void OnUpdate()
	{
	}
	
	#endregion
	
	#region Internal
	
	void Awake()
	{
		leverScript = GetComponentInChildren<LeverPull>();
		if (leverScript == null)
		{
			Debug.Log("LeverPull component missing.");
		}
		performedAction = false;
	}
	
	void Update()
	{
		if (leverScript.IsMoving())
		{
			if (performedAction == false)
			{
				performedAction = true;
				Action();
			}
		}
		else
		{
			performedAction = false;
		}
		
		OnUpdate();
	}
	
	#endregion
}
