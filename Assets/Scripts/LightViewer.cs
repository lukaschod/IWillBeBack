using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightViewer : MonoBehaviour {

	public GameObject player;
	public float mapY;
	public GameObject camera;
	public Vector3 cameraPos;
	private GameObject cameraPlayer;
	public bool loadStatic = true;
	void Start () {
		Vector3 pos = camera.transform.position;
		camera.transform.position = new Vector3 (pos.x, pos.y , pos.z);
		cameraPos = camera.transform.position;
		cameraPlayer = Instantiate (player, new Vector3(0f,mapY,0f), new Quaternion ());
	}

	public void CopyPlayer(GameObject g)
	{
		cameraPlayer = new GameObject(g.name);
		cameraPlayer.AddComponent<MeshFilter>();
		cameraPlayer.GetComponent<MeshFilter> ().mesh = g.GetComponent<MeshFilter> ().mesh;
		cameraPlayer.AddComponent<MeshRenderer>();
		cameraPlayer.GetComponent<MeshRenderer>().shadowCastingMode = g.GetComponent<MeshRenderer>().shadowCastingMode;
		cameraPlayer.GetComponent<MeshRenderer>().receiveShadows = g.GetComponent<MeshRenderer>().receiveShadows;
		cameraPlayer.GetComponent<MeshRenderer>().motionVectorGenerationMode = g.GetComponent<MeshRenderer>().motionVectorGenerationMode;
		cameraPlayer.GetComponent<MeshRenderer>().materials = g.GetComponent<MeshRenderer>().materials;
		cameraPlayer.GetComponent<MeshRenderer>().material = g.GetComponent<MeshRenderer>().material;
		cameraPlayer.transform.localScale = g.transform.localScale;
		cameraPlayer.transform.SetParent (LightManager.monoLightManager.transform);
		Vector3 pos = g.transform.position;
		cameraPlayer.transform.position = new Vector3 (pos.x, pos.y+ mapY, pos.z);
	}

	void Update () {
		Vector3 p = player.transform.position;
		cameraPlayer.transform.position = new Vector3 (p.x, p.y+ mapY, p.z);
		if (loadStatic == true)
		{
			loadStatic = false;
			foreach (LightSource id in LightManager.lightList) {
				if (id.isStatic == true) {
					GameObject g = id.RequestObject ().gameObject;
					g.transform.Translate (0, mapY, 0);
				}
			}
		}





		Vector3 ps = player.transform.position + cameraPos;
		camera.transform.position = new Vector3 (ps.x, ps.y + mapY, ps.z);
		float d = LightManager.publicLightSpeed * LightManager.monoLightManager.viewSteps ;

		foreach (LightSource id in LightManager.lightList)
		{
			if (player == id.gameObject)
				continue;
			if ((id.gameObject.transform.position - player.transform.position).sqrMagnitude > 10.0f * 10.0f)
			{
				continue;

			}
			foreach (LightRay r in id.rayList)
			{
				float dist = Mathf.Abs ((Vector3.Distance (r.pos, player.transform.position) - r.radius)) ;
				if (dist < d) {
					LightPollObject i = id.RequestObject ();
					Vector3 pos = r.pos;
					Vector3 rot = r.rot;
					i.gameObject.transform.position = new Vector3 (pos.x, pos.y + mapY, pos.z);
					i.gameObject.transform.rotation = Quaternion.Euler (rot.x, rot.y, rot.z);
				}
			}

		}
	}
}
