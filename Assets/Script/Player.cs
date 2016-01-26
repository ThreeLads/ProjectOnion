using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator animator;

	private Rigidbody2D rbody;

	private BoxCollider2D bcoll;

    private Animator anim;

    public Transform groundCheck;

    private bool facingRight = true;

    private bool Grounded = false;

	private float thrust = 7;

    private int maxspeed = 4;
	
	void Start()
	{
		rbody = GetComponent<Rigidbody2D>();
		bcoll = GetComponent<BoxCollider2D>();
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
		rbody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
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
            rbody.AddForce(Vector2.right * h * 7);

        if (Mathf.Abs(rbody.velocity.x) > maxspeed)
            rbody.velocity = new Vector2(Mathf.Sign(rbody.velocity.x) * maxspeed, rbody.velocity.y);

        if (Input.GetKeyDown ("space") && Grounded)
			Jump ();

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
	}

}