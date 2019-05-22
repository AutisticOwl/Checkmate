using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossfightSetup : MonoBehaviour {

    private Movement king;

    void Start()
    {
        king = FindObjectOfType<Movement>();
        king.speed = 0;
        king.jumpForce = 0;
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        yield return new WaitForSeconds(16);
        king.speed = 12.5f;
        king.jumpForce = 35;
    }
}
