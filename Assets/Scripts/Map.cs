using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public GameObject Cam;
    public float Speed;
    public float JumpForce;
    public float previousJumpForce;
    private bool isInMapView;
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (!isInMapView)
            {
                Camera.main.orthographicSize = 30;
                Cam.transform.position = new Vector3(35f, 18.5f, -5f);
                Movement stop = GetComponent<Movement>();
                Debug.Log(stop.jumpForce);
                previousJumpForce = stop.jumpForce;
                stop.speed = 0;
                stop.jumpForce = 0;
            }
            isInMapView = true;
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Camera.main.orthographicSize = 10.78f;
            Movement stop = GetComponent<Movement>();
            stop.speed = Speed;
            stop.jumpForce = (previousJumpForce < 0) ? -JumpForce : JumpForce;
            isInMapView = false;
        }
    }
}
