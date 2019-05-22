using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneJump : MonoBehaviour {

    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float jumpForce;
    public float checkRadius;
    private bool isGrounded = true;
    private bool jumpAgain = true;
    public float nextJump;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        if(jumpAgain)
        {
            if (Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround))
            {
                if (isGrounded)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    jumpAgain = false;
                    StartCoroutine(Stand());
                }
            }
        }
    }

    IEnumerator Stand()
    {
        yield return new WaitForSeconds(nextJump);
        jumpAgain = true;
    }
}
