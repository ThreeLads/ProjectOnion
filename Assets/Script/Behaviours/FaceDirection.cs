using UnityEngine;
using System.Collections;

public class FaceDirection : AbstractBehaviour {

	// Update is called once per frame
	void Update () {
        var right = inputState.GetButtonValue(inputButtons[0]);
        var left = inputState.GetButtonValue(inputButtons[1]);

        if(right)
        {
            inputState.direction = Directions.right;
        }
        else if(left)
        {
            inputState.direction = Directions.left;
        }

        transform.localScale = new Vector3((float)inputState.direction, 1, 1);
    }
}
