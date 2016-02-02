using UnityEngine;
using System.Collections;

public class CollisionState : MonoBehaviour {

    public LayerMask collisionLayer;
    public bool grounded;
    public bool onWall;
    public Vector2 bottomPosition = Vector2.zero;
    public Vector2 leftPosition = Vector2.zero;
    public Vector2 rightPosition = Vector2.zero;
    public float collisionRadius = 1f;
    public float boxOffset = 0.1f;
    public Color debugCollisionColour = Color.red;

    private InputState inputState;
    private BoxCollider2D boxCol;

    void Awake()
    {
        inputState = GetComponent<InputState>();
        boxCol = GetComponent<BoxCollider2D>();
    }


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

        pos = inputState.direction == Directions.right ? rightPosition : leftPosition;

        pos.x += transform.position.x;
        pos.y += transform.position.y;

        var pointA = new Vector2(inputState.direction == Directions.right ? (pos.x - boxCol.bounds.extents.x) : (pos.x + boxCol.bounds.extents.x), (pos.y - boxCol.bounds.extents.y - 0.12f));
        var pointB = new Vector2(inputState.direction == Directions.right ? (pos.x + boxCol.bounds.extents.x - 0.175f) : (pos.x - boxCol.bounds.extents.x + 0.175f), (pos.y + boxCol.bounds.extents.y - 0.15f));

        onWall = Physics2D.OverlapArea(pointA, pointB, collisionLayer);

        //Debug.DrawLine(new Vector3(pointA.x, pointA.y, 0f), new Vector3(pointB.x, pointB.y, 0f)); //| draws a line between the two points diagonal of the collision area |
    }

    void OnDrawGizmos()
    {
        Gizmos.color = debugCollisionColour;
        var positions = new Vector2[] {bottomPosition};

        foreach (var position in positions)
        {
            var pos = position;
            pos.x += transform.position.x;
            pos.y += transform.position.y;
            Gizmos.DrawWireSphere(pos, collisionRadius);
        }

    }
}
