using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRook : MonoBehaviour {

    private RookAbility rookAbility;

    public void Start()
    {
        rookAbility = FindObjectOfType<RookAbility>();
    }

    public void OnTriggerEnter2D(Collider2D player)
    {
        rookAbility.Ability += 1;
        this.gameObject.SetActive(false);
    }
}
