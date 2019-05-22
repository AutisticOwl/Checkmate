using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTriggerRook : MonoBehaviour {

    public GameObject Wall;
    private bool isTriggered;
    public float xSpeed;
    public float ySpeed;

    void Update()
    {
        if (isTriggered)
        {
            Wall.transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
        }
    }

    public void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Rook")
        {
            isTriggered = true;
        }
    }
}
