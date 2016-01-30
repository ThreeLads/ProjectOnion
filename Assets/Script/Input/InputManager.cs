using UnityEngine;
using System.Collections;


//enum of buttons that can be pressed
public enum Buttons
{
    Right,
    Left,
    Walk,
    A
}

//enum of conditions on which to assess the values of the axis
public enum condition
{
    greaterThan,
    lessThan
}

[System.Serializable]
public class InputAxisState 
{
    public string axisName; //name of the axis that is being used for input e.g Horizontal
    public float offValue; //Default value of the axis
    public Buttons button;
    public condition condition;


    //Read only function that determines whether the chosen button is pressed by comparing the value of axisName agains offValue using the set comparetor
    public bool value
    {
        get
        {
            var val = Input.GetAxisRaw(axisName);

            switch(condition)
            {
                case condition.greaterThan:
                    return val > offValue;
                    
                case condition.lessThan:
                    return val < offValue;
            }

            return false;
        }
    }
}


public class InputManager : MonoBehaviour {


    public InputAxisState[] inputs; //array of inputs
    public InputState inputState; //InputState for the contolled object
	
	// Update is called once per frame
	void Update () {
	    foreach(var input in inputs)
        {
            inputState.setButtonValue(input.button, input.value); //pass each button and its state(value) into the method of inputState
        }
	}
}
