using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class buttonState //class the be the vale of the dictionary
{
    public bool value;         //value of the button
    public float holdTime = 0; //time button has been held
}

public class InputState : MonoBehaviour {

    private Dictionary<Buttons, buttonState> buttonStates = new Dictionary<Buttons, buttonState>(); //create dictionary with the keys beng the button and the value their state and time held

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

