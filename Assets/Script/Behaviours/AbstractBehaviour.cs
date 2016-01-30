using UnityEngine;
using System.Collections;

public abstract class  AbstractBehaviour : MonoBehaviour {

    public Buttons[] inputButtons;

    protected InputState inputState;
    protected Rigidbody2D rbody;
    protected CollisionState collisionState;

    protected virtual void Awake()
    {
        inputState = GetComponent<InputState>();
        rbody = GetComponent<Rigidbody2D>();
        collisionState = GetComponent<CollisionState>();

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
