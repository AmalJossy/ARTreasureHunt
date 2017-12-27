using UnityEngine;
using System.Collections;

public class LeverPull : MonoBehaviour
{
	private bool isDown;
	private bool moving;
	private Quaternion upRotation;
	private Quaternion downRotation;
	ConnectedLeverAction LEVER;


	public bool IsMoving()
	{
		return moving;
	}

	void Start()
	{
		isDown = false;
		moving = false;
		upRotation = Quaternion.Euler(38, 0, 0);
		downRotation = Quaternion.Euler(-38, 0, 0);
	}

	public void pullit()
	{
		if (!moving) {
			if (isDown) {
				StartCoroutine (MoveUp ());
			} else {
				StartCoroutine (MoveDown ());
			}
		}
	}
	void OnMouseDown(){
		pullit ();
	}

	IEnumerator MoveUp()
	{
		moving = true;
		yield return StartCoroutine(RotateObject(transform, downRotation, upRotation, 0.25f));
		moving = false;
		isDown = false;

	}

	IEnumerator MoveDown()
	{

		moving = true;
		yield return StartCoroutine(RotateObject(transform, upRotation, downRotation, 0.25f));
		moving = false;
		isDown = true;

	}

	IEnumerator RotateObject(Transform transform, Quaternion startRotation, Quaternion endRotation, float time)
	{
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f)
		{
			i += Time.deltaTime * rate;
			transform.localRotation = Quaternion.Slerp(startRotation, endRotation, i);
			yield return null;
		}
	}

	public void ForceUpPosition()
	{
		transform.localRotation = upRotation;
		isDown = false;
		moving = false;
	}

	public void ForceDownPosition()
	{
		transform.localRotation = downRotation;
		isDown = true;
		moving = false;
	}

}
