using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	private Rigidbody2D rbody;
	private BoxCollider2D bcoll;
    private Animator anim;
    public Transform GroundCheck;
    private InputState inputState;
    
    public Buttons[] input;
    private bool facingRight = true;
    private bool Grounded = false;

	private float thrust = 15, jumpThrust = 7;
    private int maxspeed = 5;
	
	void Start()
	{
		rbody = GetComponent<Rigidbody2D>();
		bcoll = GetComponent<BoxCollider2D>();
		anim = GetComponent<Animator>();
        inputState = GetComponent<InputState>();
    }
	
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
    private void Jump()
    {
		rbody.AddForce(Vector2.up * jumpThrust, ForceMode2D.Impulse);
    }

    void Update()
    {
		Grounded = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (!Grounded && rbody.velocity.y < 0)
            anim.SetBool("Falling", true);
        else
            anim.SetBool("Falling", false);


        var right = inputState.GetButtonValue(input[0]);
        var left = inputState.GetButtonValue(input[1]);


        var velX = maxspeed;

        if (right || left)
        {
            velX *= right ? 1 : -1;
        }
        else
        {
            velX = 0;
        }

        rbody.velocity = new Vector2(velX, rbody.velocity.y);

        if (right && !facingRight)
            Flip();
        else if (left && facingRight)
            Flip();

        anim.SetBool("Running", (right || left));
    }

	void FixedUpdate ()
    {

        /*float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rbody.velocity.x < maxspeed)
            rbody.AddForce(Vector2.right * h * thrust);

        if (Mathf.Abs(rbody.velocity.x) > maxspeed)
            rbody.velocity = new Vector2(Mathf.Sign(rbody.velocity.x) * maxspeed, rbody.velocity.y);

        if (h == 0 && Mathf.Abs(rbody.velocity.x) > 0 && Grounded)
        {
            if (Mathf.Abs(rbody.velocity.x) < 0.5)
                rbody.velocity = new Vector2(0, rbody.velocity.y);
            else
                rbody.AddForce(Vector2.right * -1 * Mathf.Sign(rbody.velocity.x) * 20);
        }
       
        */

        if (Input.GetKey ("space") && Grounded)
			Jump ();
        
    }

}