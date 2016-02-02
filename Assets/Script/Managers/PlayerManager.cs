using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    private InputState inputState;
    private Run run;
    private Animator anim;
    private CollisionState collisionState;
    private Crawl CrawlBehaviour;
    private BoxCollider2D boxcol;

    void Awake()
    {
        inputState = GetComponent<InputState>();
        run = GetComponent<Run>();
        anim = GetComponent<Animator>();
        collisionState = GetComponent<CollisionState>();
        CrawlBehaviour = GetComponent<Crawl>();
        boxcol = GetComponent<BoxCollider2D>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (collisionState.grounded)
        {
            ChangeAnimationState(0);

        }

        if (inputState.absVelX > 0)
        {
            ChangeAnimationState(1);
            anim.speed = run.walking ? run.walkMultiplier : 1;
        }

        if (inputState.VelY < 0  && !collisionState.grounded)
        {
            ChangeAnimationState(3);
        }


        if (inputState.VelY > 0 && !collisionState.grounded)
        {
            ChangeAnimationState(2);
        }

        if(CrawlBehaviour.ducking)
        {
            ChangeAnimationState(4);
        }

        if (collisionState.onWall && !collisionState.grounded)
        {
            ChangeAnimationState(5);
        }

    }

    private void ChangeAnimationState(int value)
    {
        anim.SetInteger("AnimState", value);
    }
}
