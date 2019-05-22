using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour {

    public GameObject Player;
    public float speed = 400;

    public void OnTriggerEnter2D(Collider2D Player)
    {
        PlayerStats health = Player.GetComponent<PlayerStats>();
        health.PlayerHealth -= 1;
        Hit();
    }

    public void Hit()
    {
        Player.transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
