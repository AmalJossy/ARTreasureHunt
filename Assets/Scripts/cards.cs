using UnityEngine;
using System.Collections;

public class cards : MonoBehaviour {
	public float initial;

	// Use this for initialization

	void OnMouseDown(){
		Destroy (gameObject);
	}
	void Update(){
		var speed = 6.0f;
		transform.position = new Vector3 ( initial * Mathf.Sin (Time.time * speed), transform.position.y, transform.position.z);
	}
}
