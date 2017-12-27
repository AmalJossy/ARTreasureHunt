using UnityEngine;
using System.Collections;

// Provides access to the relevant device sensors.
public class Sensors : MonoBehaviour
{

	void Start()
	{
		// Enable sensors.

		Input.gyro.enabled = true;

	}

	/*public static Quaternion Attitude()
	{
		Quaternion q = Input.gyro.attitude;
		return new Quaternion(q.x, q.y, -q.z, q.w);
	}*/

	public static Vector3 Gravity()
	{
		Input.gyro.enabled = true;
		return Input.gyro.gravity;
	}
}