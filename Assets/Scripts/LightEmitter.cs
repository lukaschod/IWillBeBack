using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEmitter : MonoBehaviour {
	public bool isStatic;

	void Awake () {

		LightManager.lightList.Add (new LightSource ( gameObject, isStatic));
	}


	void OnDestroy()
	{
		var id = LightManager.lightList.Find (p => p.gameObject == gameObject);
		foreach (LightPollObject iid in id.objectPoll) {
			iid.inUse = false;
			if (iid.gameObject)
				iid.gameObject.SetActive (false);
		}
		LightManager.lightList.Remove(id);

	}
}
