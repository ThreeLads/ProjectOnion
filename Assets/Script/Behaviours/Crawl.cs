using UnityEngine;
using System.Collections;

public class Crawl : AbstractBehaviour {

    public float scale = 0.5f;
    public bool ducking;
    public float centerOffsetY = 0f;
    public float speed = 5f;

    private BoxCollider2D boxCol;
    private Vector2 origCenter;

    protected override void Awake()
    {
        base.Awake();

        boxCol = GetComponent<BoxCollider2D>();
        origCenter = boxCol.offset;
    }

    protected virtual void OnDuck(bool value)
    {
        ducking = value;

        ToggleScripts(!ducking);

        var colHeight = boxCol.size.y;

        float newOffsetY;
        float sizeReciprocal;

        if (ducking)
        {
            sizeReciprocal = scale;
            newOffsetY = boxCol.offset.y - colHeight / 2 + centerOffsetY;
        }
        else
        {
            sizeReciprocal = 1 / scale;
            newOffsetY = origCenter.y;
        }

        colHeight *= sizeReciprocal;
        boxCol.size = new Vector2(boxCol.size.x, colHeight);
        boxCol.offset = new Vector2(boxCol.offset.x, newOffsetY);

    }

	
	// Update is called once per frame
	void Update () {

        var canDuck = inputState.GetButtonValue(inputButtons[0]);
        if (canDuck && collisionState.grounded && !ducking)
        {
            OnDuck(true);
        }
        else if (ducking && !canDuck)
        {
            OnDuck(false);
        }

        var right = inputState.GetButtonValue(inputButtons[1]);
        var left = inputState.GetButtonValue(inputButtons[2]);

        if (right || left)
        { 
            var tmpSpeed = speed;
            var velX = tmpSpeed * (float)inputState.direction;
            rbody.velocity = new Vector2(velX, rbody.velocity.y);
        }
        else
        {
            rbody.velocity = new Vector2(0, rbody.velocity.y);
        }
    }
}
