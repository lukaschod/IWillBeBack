using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTerrain : MonoBehaviour {

	public GameObject[] tiles;

	void Start () {
		for (int x = -10; x < 10; x++)
		{
			for (int y = -5; y < 5; y++)
			{
				AddTile (0, x, 0,y);
			}
		}
	}

	void AddTile(int id, int x, int y, int z)
	{
		GameObject g = Instantiate(tiles[id],new Vector3 (x * 2, 0.5f + y, z * 2), Quaternion.identity) as GameObject;
		g.transform.parent = gameObject.transform;
	}
}
