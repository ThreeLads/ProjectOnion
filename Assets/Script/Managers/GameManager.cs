using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private World world;

	// Use this for initialization
	void Awake () {
		this.world = GetComponent<World> ();
		InitGame();
	}

	void InitGame()
	{
		this.world.Generate ();
	}	
	
	// Update is called once per frame
	void Update () {
	
	}
}
