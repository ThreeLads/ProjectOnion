using UnityEngine;
using System.Collections;

public class WallSlide : WallStick {

    public float slidevelocity = -5f;
    public float slideMultiplier = 2f;
    public float stickTime = 1f;

    private float timeOnWall = 0f;

	// Update is called once per frame
	override protected void Update () {
        if (collisionState.onWall && !collisionState.grounded)
        {
            if (!OnWallDetected && timeOnWall < stickTime)
            {
                OnStick();
                ToggleScripts(false);
                OnWallDetected = true;
            }
            else if(timeOnWall > stickTime)
            {
                Destick();
                var VelY = slidevelocity;
                if (inputState.GetButtonValue(inputButtons[0]))
                    VelY *= slideMultiplier;

                rbody.velocity = new Vector2(rbody.velocity.x, VelY);
            }
        }
        else
        {
            if (OnWallDetected)
            {
                Destick();
                timeOnWall = 0f;
                ToggleScripts(true);
                OnWallDetected = false;
            }
        }

        if(OnWallDetected)
            timeOnWall += Time.deltaTime;
    }

    protected override void OnStick()
    {
        rbody.velocity = Vector2.zero;
        base.OnStick();
    }
}
