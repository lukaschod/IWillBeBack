using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAControler : MonoBehaviour {


	bool jump = false;
	float jumpTimer = 0f;

	void Update () {
		Rigidbody r = GetComponent<Rigidbody> ();

		r.AddForce (new Vector3 (Input.GetAxis("Horizontal") * 10, 0, Input.GetAxis("Vertical") * 10));
		if (Input.GetAxis ("Fire1") > 0 && jump == false)
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
