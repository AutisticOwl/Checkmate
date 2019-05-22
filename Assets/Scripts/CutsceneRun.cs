using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneRun : MonoBehaviour {

    public float Speed;
    public float turnTime;
    private bool turn = true;
	
	void Update ()
    {
        this.transform.Translate(Speed * Time.deltaTime, 0, 0);
        if(turn)
        {
            turn = !turn;
            StartCoroutine(Turn());
        }
    }

    IEnumerator Turn()
    {
        yield return new WaitForSeconds(turnTime);
        Speed *= -1;
        turn = !turn;
    }
}
