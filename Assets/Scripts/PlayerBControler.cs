using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBControler : MonoBehaviour {

	bool jump = false;
	float jumpTimer = 0f;

	void Update () {
		Rigidbody r = GetComponent<Rigidbody> ();

		if (Input.GetKey (KeyCode.A))
			r.AddForce (new Vector3 (-10f,0f,0f));
		if (Input.GetKey (KeyCode.D))
			r.AddForce (new Vector3 (10f,0f,0f));
		if (Input.GetKey (KeyCode.W))
			r.AddForce (new Vector3 (0f,0f,10f));
		if (Input.GetKey (KeyCode.S))
			r.AddForce (new Vector3 (0f,0f,-10f));
		if (Input.GetKey (KeyCode.Space)  && jump == false)
		{
			jump = true;
			r.AddForce (new Vector3 (0, 300, 0));
		}
		if (jump == true) {
			jumpTimer = jumpTimer + 1;
			if (jumpTimer > 60) {
				jumpTimer = 0;
				jump = false;
			}
		}
	}
}
