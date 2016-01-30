using UnityEngine;
using System.Collections;

public class LongJump : Jump {

    public float longJumpDelay = .15f;
    public float longJumpMultiplier = 1.2f;
    public bool canLongJump;
    public bool isLongJump;

    protected override void Update()
    {
        var canJump = inputState.GetButtonValue(inputButtons[0]);
        var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

        if (!canJump)
            canLongJump = false;

        if (collisionState.grounded && isLongJump)
            isLongJump = false;

        base.Update();

        if(canLongJump && !collisionState.grounded && holdTime > longJumpDelay)
        {
            var vel = rbody.velocity;
            rbody.velocity = new Vector2(vel.x, JumpForce * longJumpMultiplier);
            canLongJump = false;
            isLongJump = true;
        }
    }

    protected override void OnJump()
    {
        base.OnJump();
        canLongJump = true;
    }
}

