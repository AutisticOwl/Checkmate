using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPortalBishop : MonoBehaviour {

    public GameObject Player;
    public float portalX;
    public float portalY;

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Bishop")
        {
            Player.transform.position = new Vector2(portalX, portalY);
        }
    }
}
