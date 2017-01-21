using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

	public static List<LightSource> lightList = new List<LightSource>();
	public float lightSpeed;
	public float lightDistance;
	public static float publicLightSpeed;
	public static LightManager monoLightManager;
	public int viewSteps;
	public int delay;
	void Start()
	{
		monoLightManager = this;	
	
	}

	void Update () {
		publicLightSpeed = lightSpeed;
		foreach (LightSource id in lightList)
		{
			if (id.isStatic == true)
				continue;
			Vector3 p = id.gameObject.transform.position;
			id.rayList.Add (new LightRay (new Vector3(p.x,p.y,p.z))); 

			List<LightRay> removeList = new List<LightRay> ();
			foreach (LightRay r in id.rayList)
			{
				r.radius = r.radius + lightSpeed;
				if (r.radius > lightDistance) {
					removeList.Add (r);
				}
			}
			foreach (LightRay r in removeList)
			{
				id.rayList.Remove (r);
			}
			removeList.Clear ();

			foreach (LightPollObject iid in id.objectPoll) {
				iid.delay = iid.delay + 1;
				iid.gameObject.SetActive (true);
				if (iid.delay > delay) {
					iid.gameObject.SetActive (false);
					iid.inUse = false;
				}
			}
		}
	}
}

public class LightSource {
	public List<LightRay> rayList;
	public GameObject gameObject;
	public List<LightPollObject> objectPoll;
	public bool isStatic;
	public LightSource(GameObject g, bool s)
	{
		isStatic = s;
		gameObject = g;
		rayList =  new List<LightRay>();
		objectPoll = new List<LightPollObject>();
	}

	public LightPollObject RequestObject()
	{
		foreach (LightPollObject id in objectPoll) {
			if (id.inUse == false) {
				id.inUse = true;
				id.delay = 0;
				id.gameObject.SetActive (true);
				Vector3 rot = gameObject.transform.rotation.eulerAngles;
				id.gameObject.transform.localRotation = Quaternion.Euler (rot.x,rot.y ,rot.z);
				return(id);
			}
		}
		LightPollObject p = new LightPollObject(gameObject);
		p.inUse = true;

		objectPoll.Add (p);
		return(p);
	}

}

public class LightPollObject
{
	public int delay = 0;
	public bool inUse = false;
	public GameObject gameObject;
	public LightPollObject(GameObject g)
	{
		gameObject = new GameObject(g.name);
		gameObject.AddComponent<MeshFilter>();
		gameObject.GetComponent<MeshFilter> ().mesh = g.GetComponent<MeshFilter> ().mesh;
		gameObject.AddComponent<MeshRenderer>();
		gameObject.GetComponent<MeshRenderer>().shadowCastingMode = g.GetComponent<MeshRenderer>().shadowCastingMode;
		gameObject.GetComponent<MeshRenderer>().receiveShadows = g.GetComponent<MeshRenderer>().receiveShadows;
		gameObject.GetComponent<MeshRenderer>().motionVectorGenerationMode = g.GetComponent<MeshRenderer>().motionVectorGenerationMode;
		gameObject.GetComponent<MeshRenderer>().materials = g.GetComponent<MeshRenderer>().materials;
		gameObject.GetComponent<MeshRenderer>().material = g.GetComponent<MeshRenderer>().material;
		gameObject.transform.localScale = g.transform.localScale;
		gameObject.transform.SetParent (LightManager.monoLightManager.transform);
		Vector3 pos = g.transform.position;
		gameObject.transform.position = new Vector3 (pos.x, pos.y, pos.z);
		Vector3 rot = g.transform.rotation.eulerAngles;
		gameObject.transform.Rotate (rot.x,rot.y ,rot.z);
	}


}

public class LightRay {

	public float radius;
	public Vector3 pos;
	public Vector3 rot;

	public LightRay(Vector3 p)
	{
		pos = p;
		radius = 0;
	}
}
