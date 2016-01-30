using UnityEngine;
using System.Collections;

public class Run : AbstractBehaviour
{

    public float speed = 5f;
    public float walkMultiplier = 2f;
    public bool walking = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);
        var walk = inputState.GetButtonValue(inputButtons[2]);

        if (right || left)
        {
            walking = false;

            var tmpSpeed = speed;

            if (walk && walkMultiplier > 0 && collisionState.grounded)
            {
                walking = true;
                tmpSpeed *= walkMultiplier;
            }
            
            var velX = tmpSpeed * (float)inputState.direction;
            rbody.velocity = new Vector2(velX, rbody.velocity.y);
        }
        else
        {
            rbody.velocity = new Vector2(0, rbody.velocity.y);
        }
    }
}