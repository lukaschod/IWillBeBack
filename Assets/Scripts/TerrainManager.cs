using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour {
	public GameObject[] tiles;

	void Start () {
		
		for (int i = -25; i < 25; i++)
		{
			AddTile (0, i,1, 10);
			AddTile (0, i,1, -10);
		}

		for (int i = -10; i < 10; i++)
		{
			AddTile (0, 25,1, i);
			AddTile (0, -25,1, i);
		}

		for (int i = 0; i < 5; i++) {
			AddTile (0, 0, i, 4);
			AddTile (0, 0, i, 5);
			AddTile (0, 0, i, -4);
			AddTile (0, 0, i, -5);
		}

		for (int i = -5; i < 6; i++) {
			AddTile (0, 0, 5, i);
			AddTile (0, 0, 6, i);
		}


	}
	
	void AddTile(int id, int x, int y, int z)
	{
		GameObject g = Instantiate(tiles[id],new Vector3 (x, 0.5f + y, z), Quaternion.identity) as GameObject;
		g.transform.parent = gameObject.transform;
	
	}


}
