using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookCutsceneCastling : MonoBehaviour {

    private bool change = false;
    private bool changeBack = false;
    public GameObject King;

    void Start()
    {
        StartCoroutine(Cooldown());
    }

    void Update()
    {
        if(change == true)
        {
            this.transform.Translate(5, 0, 0);
            King.transform.Translate(-5, 0, 0);
            change = false;
            StartCoroutine(Cooldown2());
        }

        if (changeBack == true)
        {
            this.transform.Translate(-5, 0, 0);
            King.transform.Translate(5, 0, 0);
            changeBack = false;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(3);
        change = true;
    }
    IEnumerator Cooldown2()
    {
        yield return new WaitForSeconds(3);
        changeBack = true;
    }
}