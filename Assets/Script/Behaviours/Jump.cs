using UnityEngine;
using System.Collections;

public class Jump : AbstractBehaviour {

    public float JumpSpeed = 50f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        var canJump = inputState.GetButtonValue(inputButtons[0]);

        if (collisionState.grounded)
        {
            if(canJump)
            {
                OnJump();
            }
        }
	}

    protected virtual void OnJump()
    {
        var vel = rbody.velocity;

        rbody.velocity = new Vector2(vel.x, JumpSpeed);
    }


}
