using UnityEngine;
using System.Collections;

public class Jump : AbstractBehaviour {

    public float JumpForce = 50f;
    public float JumpDelay = 0.1f;
    public int JumpCount = 2;

    protected float lastJumpTime = 0f;
    protected int jumpsLeft = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update ()
    { 
        var canJump = inputState.GetButtonValue(inputButtons[0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

        Debug.Log(holdTime);

        if (collisionState.grounded)
        {
            if (canJump && holdTime < 0.1f)
            {
                jumpsLeft = JumpCount - 1;
                OnJump();
            }
        }
        else
        {
            if (canJump && holdTime < 0.1f && Time.time - lastJumpTime > JumpDelay)
            {
                if (jumpsLeft > 0)
                {
                    OnJump();
                    jumpsLeft--;
                }
            }
        }

	}

    protected virtual void OnJump()
    {
        var vel = rbody.velocity;
        lastJumpTime = Time.time;
        //rbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        rbody.velocity = new Vector2(vel.x, JumpForce);
    }


}
