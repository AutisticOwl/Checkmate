using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookAbility : MonoBehaviour
{
    private CharacterManager charMang;
    public GameObject RookJump;
    public GameObject JumpCross;
    public int Ability;

    void Start()
    {
        charMang = FindObjectOfType<CharacterManager>();
    }

    void Update()
    {
        if (charMang.currentPlayer.name == "Rook")
        {
            RookJump.SetActive(true);
        }
        else
        {
            RookJump.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.C) && name == "Rook" && charMang.currentPlayer.name == "Rook" && Ability > 0)
        {
            GetComponent<Rigidbody2D>().gravityScale *= -1;
            this.transform.localScale *= -1;
            Ability--;

            Movement jump = GetComponent<Movement>();
            jump.jumpForce *= -1;
        }
        if (Ability < 1)
        {
            JumpCross.SetActive(true);
        }
    }
}