using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentPlatform : MonoBehaviour {

    public GameObject Transparent;
    public GameObject JumpCheck;
    private CharacterManager Manager;
    private Movement mvmt;
    private bool isSolid = false;
    private bool solidCheck = true;
    private bool notInCenter = true;

    void Start()
    {
        Manager = FindObjectOfType<CharacterManager>();
    }

    void Update ()
    {
        mvmt = Manager.currentPlayer.GetComponent<Movement>();
        if (Change())
        {
            isSolid = !isSolid;
        }

        if (notInCenter == true)
        {
            if (isSolid)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                Transparent.SetActive(true);
                gameObject.layer = 0;
                JumpCheck.SetActive(false);
            }

            if (!isSolid)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                Transparent.SetActive(false);
                gameObject.layer = 8;
                JumpCheck.SetActive(true);
            }
        }
        notInCenter = true;
    }

    bool Change()
    {
        if (Manager.currentPlayer.name=="King")
        {
            if (Input.GetKeyUp(KeyCode.Y))
            {
                solidCheck = true;
            }
            if (Input.GetKeyDown(KeyCode.Y) && solidCheck && mvmt.isGrounded)
            {
                solidCheck = false;
                return true;
            }
            else return false;
        }
        else return false;
    }

    void OnTriggerStay2D (Collider2D Center)
    {
        notInCenter = false;
    }

    void OnTriggerExit2D(Collider2D Center)
    {
        notInCenter = true;
    }
    
}
