using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D rbody;

	private BoxCollider2D bcoll;

	private float thrust = 5;
	
	void Start()
	{
		rbody = GetComponent<Rigidbody2D>();
		bcoll = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space") && rbody.IsTouchingLayers())
		{
			rbody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
		}

		if (Input.GetKey ("a")) {
			rbody.AddForce(Vector2.left * thrust);
		}

		if (Input.GetKey ("d")) {
			rbody.AddForce(Vector2.right * thrust);
		}
	}
}
