using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookCutscene : MonoBehaviour {

    private bool changeAgain = false;
    public float nextJump;

    void Start()
    {
        StartCoroutine(Cooldown());
    }
    void Update()
    {
        if(changeAgain == true)
        {
            GetComponent<Rigidbody2D>().gravityScale *= -1;
            this.transform.localScale *= -1;
            changeAgain = false;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(nextJump);
        changeAgain = true;
    }
}