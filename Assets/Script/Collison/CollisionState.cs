using UnityEngine;
using System.Collections;

public class CollisionState : MonoBehaviour {

    public LayerMask collisionLayer;
    public bool grounded;
    public Vector2 bottomPosition = Vector2.zero;
    public float collisionRadius = 1f;
    public Color debugCollisionColour = Color.red;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        var pos = bottomPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        grounded = Physics2D.OverlapCircle(pos, collisionRadius, collisionLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = debugCollisionColour;
        var pos = bottomPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Gizmos.DrawWireSphere(pos, collisionRadius);
    }
}
