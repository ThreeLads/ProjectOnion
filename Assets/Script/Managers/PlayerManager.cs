using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    private InputState inputState;
    private Run run;
    private Animator anim;

    void Awake()
    {
        inputState = GetComponent<InputState>();
        run = GetComponent<Run>();
        anim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(inputState.absVelX == 0)
        {
            ChangeAnimationState(0);
        }

        if (inputState.absVelX > 0)
        {
            ChangeAnimationState(1);
            anim.speed = run.walking ? run.walkMultiplier : 1;
        }

        if (inputState.VelY < 0 /* && grounded*/)
        {
            ChangeAnimationState(3);
        }
            

    }

    private void ChangeAnimationState(int value)
    {
        anim.SetInteger("AnimState", value);
    }
}
