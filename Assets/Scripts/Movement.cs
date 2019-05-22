using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public static float moveInput { get; private set; }

    private Rigidbody2D rb;
    private bool faceRight = true;
    public static int health;
    public bool isGrounded = false;
    public float checkRadius;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    //public GameObject arrow;
    private int extraJumps;
    public int extraJumpValue;
    public bool disableSelf { get; set; }
    private int timer;

    private AudioSource audioSource;
    public AudioClip stepClip;
    public AudioClip jumpClip;
    public event Action OnGroundCollisionEnter;
    public event Action OnGroundCollisionStay;
    public GameObject deathEffect;
    public GameObject sprite;
    public int level;
    
    void Start()
    {
        OnGroundCollisionEnter = delegate { };
        OnGroundCollisionStay = delegate { };
        disableSelf = true;
        if (health == 0)
            health = 100;
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = this.stepClip;
        audioSource.clip = this.jumpClip;
        DashAbility abil = GetComponent<DashAbility>();
        if (abil != null)
        {
            OnGroundCollisionEnter += abil.PlayerIsGrounded;
            OnGroundCollisionStay += abil.PlayerIsGrounded;
        }
    }

    public void FixedUpdateMe()
    {
        isGrounded = JumpDelay();
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (faceRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (faceRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    public IEnumerator EnableForSecs(float seconds)
    {
        this.disableSelf = false;
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSecondsRealtime(seconds);
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        this.disableSelf = true;
    }
    public void UpdateMe()
    {
        if (isGrounded && moveInput != 0 && !audioSource.isPlaying)
            audioSource.PlayOneShot(stepClip);

        if (Input.GetKeyDown(KeyCode.Y) && isGrounded && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(jumpClip);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (isGrounded)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
            else
            {
                if (extraJumps > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    extraJumps--;
                }
            }
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 8)
        {
            if (disableSelf)
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
            OnGroundCollisionEnter.Invoke();
            extraJumps = extraJumpValue;
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if (disableSelf)
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                disableSelf = false;
            }
            OnGroundCollisionStay();
        }
    }
    public bool JumpDelay()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround))
        {
            timer = 5;
        }
        timer--;
        if (timer > 0)
        {
            return true;
        }
        else return false;

    }

    void OnTriggerEnter2D(Collider2D death)
    {
        if (death.gameObject.tag == "Death")
        {
            deathEffect.SetActive(true);
            sprite.SetActive(false);
            speed = 0;
            jumpForce = 0;
            StartCoroutine(LoadAsync(level));
        }
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        yield return new WaitForSeconds(2);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
