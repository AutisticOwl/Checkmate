using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenAttackSpear : MonoBehaviour
{

    private CharacterManager charMang;
    public Animator SpearAnim;
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
                SpearAnim.SetTrigger("Spear");
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
