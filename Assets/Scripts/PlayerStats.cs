using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public GameObject Player;
    public GameObject DeathEffect;
    public float PlayerHealth;

	void Update ()
    {
        if (PlayerHealth < 1)
        {
            Die();
        }
    }

    private void Die()
    {
        Player.SetActive(false);
        DeathEffect.SetActive(true);
    }
}
