using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour {

    public GameObject Button;
    public float ySpeed;
    public float xSpeed;
    private bool isTriggered;

    void Update()
    {
        if (isTriggered)
        {
            Button.transform.Translate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);
        }
    }

    public void OnTriggerEnter2D (Collider2D other)
    {
        if (true)
        {
            isTriggered = true;
        }
    }
}
