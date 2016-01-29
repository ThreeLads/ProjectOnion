using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class buttonState //class the be the vale of the dictionary
{
    public bool value;         //value of the button
    public float holdTime = 0; //time button has been held
}

public enum Directions
{
    right = 1,
    left = -1
}

public class InputState : MonoBehaviour {

    public Directions direction = Directions.right;
    public float VelX = 0f;
    public float VelY = 0f;
    public float absVelX = 0f;
    public float absVelY = 0f;

    private Rigidbody2D rbody;

    private Dictionary<Buttons, buttonState> buttonStates = new Dictionary<Buttons, buttonState>(); //create dictionary with the keys beng the button and the value their state and time held

    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        absVelX = Mathf.Abs(rbody.velocity.x);
        absVelY = Mathf.Abs(rbody.velocity.y);
        VelX = rbody.velocity.x;
        VelY = rbody.velocity.y;
    }

    public void setButtonValue(Buttons key, bool value) //set the dictionary
    {
        if(!buttonStates.ContainsKey(key))             //check for the key in the dictionary and if missing create it
            buttonStates.Add(key, new buttonState());

        var state = buttonStates[key]; // refference the hold time and value of the parsed in key from the dictionary

        if(state.value && !value) //parsed state and recorded state are different therefore button has been released
        {
            state.holdTime = 0;
        }
        else if (state.value && value) //parsed and recorded match therefore being held
        {
            state.holdTime += Time.deltaTime;
        }
        state.value = value; //set the recorded value to the parsed value
    }

    
    public bool GetButtonValue(Buttons key) // function for determining whether the parsed button is pressed
    {
        if (buttonStates.ContainsKey(key)) //check button exists in the dictionary
            return buttonStates[key].value; //return the state of the parsed button
        else
            return false; //can't find button so return false
    }
}

