using UnityEngine;
using System.Collections;

public class WallSlide : WallStick {

    public float slidevelocity = -5f;
	
	// Update is called once per frame
	override protected void Update () {
        base.Update();

        if(OnWallDetected)
        {
            var VelY = slidevelocity;
            rbody.velocity = new Vector2(rbody.velocity.x, VelY);
        }
	}

    protected override void OnStick()
    {
        rbody.velocity = Vector2.zero;
    }

    protected override void OffWall()
    {
        //Make OffWall do nothing
    }
}
