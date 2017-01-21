using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugLightManager : MonoBehaviour {

	public Text text1;
	public Text text2;
	public Text text3;

	void Update () {
		text1.text = "LightSources: " + LightManager.lightList.Count.ToString();
		int count = 0;
		int count2 = 0;
		foreach (LightSource id in LightManager.lightList) {
			count = count + id.rayList.Count;
			count2 = count2 + id.objectPoll.Count;
		}
		text2.text = "LightRays: " + count.ToString();
		text3.text = "LightPoll: " + count2.ToString();

	}
}
