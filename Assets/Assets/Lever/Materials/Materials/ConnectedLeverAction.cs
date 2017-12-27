using UnityEngine;
using System.Collections;

public class ConnectedLeverAction : LeverAction
{   
	public int i;
	
	private ConnectedLeverPuzzleLogic logic;
	
	void Start()
	{
		logic = GetComponentInParent<ConnectedLeverPuzzleLogic>();
	}
	
	override protected void Action()
	{
		logic.Toggle(i);
	}
	

}