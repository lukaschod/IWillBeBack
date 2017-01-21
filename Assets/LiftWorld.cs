using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftWorld : MonoBehaviour {

	public float distortion;

	void Update () {
		var pos = transform.position;
		transform.position = new Vector3 (pos.x, pos.y + distortion, pos.z);
	}
}
