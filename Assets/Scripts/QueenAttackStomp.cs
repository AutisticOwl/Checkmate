using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenAttackStomp : MonoBehaviour {

    private CharacterManager charMang;
    public Animator StompAnim;
    private bool animDone = true;

    void Start()
    {
        charMang = FindObjectOfType<CharacterManager>();
    }

    void Update()
    {
        if (animDone == true)
        {
            if (charMang.currentPlayer.name == "King")
            {
                StompAnim.SetTrigger("Stomp");
                animDone = false;
                StartCoroutine(Cooldown());
            }
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(4);
        animDone = true;
    }
}
