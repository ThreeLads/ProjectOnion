using UnityEngine;
using System.Collections.Generic;

public class World : MonoBehaviour {

	public GameObject tileForFloor;

	private Transform tileHolder;

	private List<Vector3> gridPositions = new List<Vector3>();

	private int width = 20, height = 2;

	void SetupTiles()
	{
		tileHolder = new GameObject ("Tiles").transform;

		for (float x = -10; x < this.width; x += 0.5f)
		{
			for (float y = -30; y < -2; y += 0.5f)
			{
				GameObject tileInstance = Instantiate(this.tileForFloor, new Vector3(x, y, 0.0F), Quaternion.identity) as GameObject;

				tileInstance.transform.SetParent(this.tileHolder);
			}
		}
	}

	public void Generate()
	{
		this.SetupTiles ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
