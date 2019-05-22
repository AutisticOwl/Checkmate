using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneMenu : MonoBehaviour {

    public GameObject King;
    public GameObject Horse;
    public GameObject BishopRun;
    public GameObject BishopJump;
    public GameObject KingJump;

    public GameObject GroundRun1;
    public GameObject GroundRun2;
    public GameObject GroundJump;

    public GameObject LeftKey;
    public GameObject RightKey;

    public GameObject Continue;

    private bool pressable = true;
    private bool leftArrowBlock = false;

    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.RightArrow) && pressable && leftArrowBlock == false)
        {
            King.transform.Translate(100, 0, 0);
            BishopRun.transform.Translate(100, 0, 0);
            GroundRun1.transform.Translate(100, 0, 0);
            GroundRun2.transform.Translate(100, 0, 0);

            Horse.transform.Translate(-100, 0, 0);
            BishopJump.transform.Translate(-100, 0, 0);
            KingJump.transform.Translate(-100, 0, 0);
            GroundJump.transform.Translate(-100, 0, 0);

            RightKey.SetActive(false);
            LeftKey.SetActive(true);

            Continue.SetActive(true);

            pressable = !pressable;
            StartCoroutine(Cooldown());
            leftArrowBlock = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && pressable && leftArrowBlock == true)
        {
            King.transform.Translate(-100, 0, 0);
            BishopRun.transform.Translate(-100, 0, 0);
            GroundRun1.transform.Translate(-100, 0, 0);
            GroundRun2.transform.Translate(-100, 0, 0);

            Horse.transform.Translate(100, 0, 0);
            BishopJump.transform.Translate(100, 0, 0);
            KingJump.transform.Translate(100, 0, 0);
            GroundJump.transform.Translate(100, 0, 0);

            RightKey.SetActive(true);
            LeftKey.SetActive(false);

            pressable = !pressable;
            StartCoroutine(Cooldown());
            leftArrowBlock = false;
        }
    }

    IEnumerator Cooldown ()
    {
        yield return new WaitForSeconds(.25f);
        pressable = !pressable;
    }
}
