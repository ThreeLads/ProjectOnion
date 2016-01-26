using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	private Rigidbody2D rbody;

	private BoxCollider2D bcoll;

    private Animator anim;

    public Transform groundCheck;

    private bool facingRight = true;

    private bool Grounded = false;

	private float thrust = 7, jumpThrust = 5;

    private int maxspeed = 5;
	
	void Start()
	{
		rbody = GetComponent<Rigidbody2D>();
		bcoll = GetComponent<BoxCollider2D>();
		anim = GetComponent<Animator>();
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
        Grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        anim.SetBool("OnGround", Grounded);
    }

	void FixedUpdate ()
    {
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rbody.velocity.x < maxspeed)
            rbody.AddForce(Vector2.right * h * thrust);

        if (Mathf.Abs(rbody.velocity.x) > maxspeed)
            rbody.velocity = new Vector2(Mathf.Sign(rbody.velocity.x) * maxspeed, rbody.velocity.y);

        if (h == 0 && Mathf.Abs(rbody.velocity.x) > 0)
        {
            if (Mathf.Abs(rbody.velocity.x) < 0.5)
                rbody.velocity = new Vector2(0, rbody.velocity.y);
            else
                rbody.AddForce(Vector2.right * -1 * Mathf.Sign(rbody.velocity.x) * 10);
        }
       
        if (Input.GetKeyDown ("space") && rbody.IsTouchingLayers())
			Jump ();

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
	}

}