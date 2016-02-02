using UnityEngine;
using System.Collections;

public class WallStick : AbstractBehaviour {

    public bool OnWallDetected;

    protected float defaultGravityScale;
    protected float defaultDrag;


    void Start()
    {
        defaultGravityScale = rbody.gravityScale;
        defaultDrag = rbody.drag;
    }

    // Update is called once per frame
    protected virtual void Update () {
	    if (collisionState.onWall)
        {
            if (!OnWallDetected)
            {
                OnStick();
                ToggleScripts(false);
                OnWallDetected = true;
            }     
        }
        else
        {
            if(OnWallDetected)
            {
                OffWall();
                ToggleScripts(true);
                OnWallDetected = false;
            }
        }
	}

    protected virtual void OnStick()
    {
        if (!collisionState.grounded && Mathf.Abs(rbody.velocity.y) > 0)
        {
            rbody.gravityScale = 0f;
            rbody.drag = 100f;
        }
    }

    protected virtual void OffWall()
    {
        if (rbody.gravityScale != defaultGravityScale)
        {
            rbody.gravityScale = defaultGravityScale;
            rbody.drag = defaultDrag;
        }
    }
}
