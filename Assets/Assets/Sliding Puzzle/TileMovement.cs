using UnityEngine;
using System.Collections;

public class TileMovement : MonoBehaviour
{
	public int tileNumber;

    private bool isMoving;

	private SlidingPuzzleLogic logic;
	
	void Start()
	{
		logic = GetComponentInParent<SlidingPuzzleLogic>();
		isMoving = false;
	}
    
    void movetile()
    {
		if (!isMoving)
		{
			
				int moveNumber = logic.MoveTile(tileNumber);

				if (moveNumber != 0)
				{
					///not possible hint sound or something
				}

				if (moveNumber == 1)
				{
					StartCoroutine(MoveRight());
				}
				else if (moveNumber == -1)
				{
					StartCoroutine(MoveLeft());
				}
				else if (moveNumber == 2)
				{
					StartCoroutine(MoveDown());
				}
				else if (moveNumber == -2)
				{
					StartCoroutine(MoveUp());
				}

        }
    }

	IEnumerator MoveRight()
	{
		isMoving = true;
		Vector3 start = transform.localPosition;
		Vector3 end = new Vector3(start.x - logic.delta, start.y, start.z);
		yield return StartCoroutine(MoveObject(transform, start, end, 0.25f));
		isMoving = false;
	}

	IEnumerator MoveLeft()
	{
		isMoving = true;
		Vector3 start = transform.localPosition;
		Vector3 end = new Vector3(start.x + logic.delta, start.y, start.z);
		yield return StartCoroutine(MoveObject(transform, start, end, 0.25f));
		isMoving = false;
	}

	IEnumerator MoveDown()
	{
		isMoving = true;
		Vector3 start = transform.localPosition;
		Vector3 end = new Vector3(start.x, start.y - logic.delta, start.z);
		yield return StartCoroutine(MoveObject(transform, start, end, 0.25f));
		isMoving = false;
	}

	IEnumerator MoveUp()
	{
		isMoving = true;
		Vector3 start = transform.localPosition;
		Vector3 end = new Vector3(start.x, start.y + logic.delta, start.z);
		yield return StartCoroutine(MoveObject(transform, start, end, 0.25f));
		isMoving = false;
	}

	IEnumerator MoveObject(Transform transform, Vector3 startPos, Vector3 endPos, float time)
	{
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f)
		{
			i += Time.deltaTime * rate;
			transform.localPosition = Vector3.Lerp(startPos, endPos, i);
			yield return null;
		}
	}

	void OnMouseDown(){
		movetile ();
	}
		
}