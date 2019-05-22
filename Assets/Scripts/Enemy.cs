using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jump;
    private bool grounded;

    public bool movingRight = true;
    public Transform groundDetection;


    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(grounded == true)
        {
            rb.velocity = Vector2.up * jump;
            grounded = false;
        }

        RaycastHit2D ledge = Physics2D.Raycast(groundDetection.position, Vector2.down, 2);
        if(ledge.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D jumper)
    {

        if (jumper.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}