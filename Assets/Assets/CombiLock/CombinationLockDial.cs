using UnityEngine;
using System.Collections;

public class CombinationLockDial : MonoBehaviour {

    private int digit;
    private bool turning;
	CombinationLockPuzzleLogic combilogic;// = gameObject.GetComponentsInParent<CombinationLockPuzzleLogic>();
	private float angle;

    void Start()
    {
        digit = 0;
		angle = 54;
        turning = false;
		combilogic = gameObject.GetComponentsInParent<CombinationLockPuzzleLogic>()[0];
    }

	void OnMouseDown() {
            if (!turning)
            {
                StartCoroutine(RotateDial());
            }
    }
	void OnMouseUp(){
		combilogic.validatelock ();
	}
    
    IEnumerator RotateDial()
    {

			digit = (digit + 1) % 10;
            turning = true;
            yield return StartCoroutine(RotateOnePosition(0.25f));
            turning = false;
    }
    
    IEnumerator RotateOnePosition(float time)
    {
        float i = 0.0f;
        float rate = 1.0f / time;
		Quaternion startRotation = Quaternion.Euler(angle, 0, 0);
		angle = angle + 18;
		Quaternion endRotation = Quaternion.Euler(angle, 0, 0);
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localRotation = Quaternion.Slerp(startRotation, endRotation, i);
            yield return null;
        }
    }
	public void SetDigit(int i)
	{
		if (i < 0 || i > 9)
		{
			Debug.Log("Combination Lock: Digit set to out of bounds value.");
		}

		digit = i;

		switch(i)
		{
		case 0:
			angle = 54;
			break;

		case 1:
			angle = 72;
			break;

		case 2:
			angle = 90;
			break;

		case 3:
			angle = 108;
			break;

		case 4:
			angle = 126;
			break;

		case 5:
			angle = 144;
			break;

		case 6:
			angle = 162;
			break;

		case 7:
			angle = 180;
			break;

		case 8:
			angle = 198;
			break;

		case 9:
			angle = 216;
			break;

		default:
			break;
		}

		transform.localRotation = Quaternion.Euler(angle, 0, 0);
	}
		

	public int GetDigit()
	{
		return digit;
	}

}
