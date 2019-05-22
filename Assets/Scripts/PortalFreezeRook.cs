using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalFreezeRook : MonoBehaviour {

    public float Speed;
    public float JumpForce;

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "PortalRook")
        {
            StartCoroutine(Teleport());
            Movement stop = GetComponent<Movement>();
            stop.speed = 0;
            stop.jumpForce = 0;
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1.5f);
        Movement stop = GetComponent<Movement>();
        stop.speed = Speed;
        stop.jumpForce = JumpForce;
    }
}
