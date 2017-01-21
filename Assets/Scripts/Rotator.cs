using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, speed, 0);

		//Rigidbody rb = GetComponent<Rigidbody> ();
		//rb.AddTorque (new Vector3 (0, 1, 0));

	}
}
