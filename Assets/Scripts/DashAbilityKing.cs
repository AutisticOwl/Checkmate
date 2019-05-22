using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbilityKing : MonoBehaviour
{
    private CharacterManager charMang;
    public float dashSpeed;
    private float remainingTime;
    public float maxDashTime;
    public float range;
    private bool canDash;
    private bool isDashing;

    void Start()
    {
        charMang = FindObjectOfType<CharacterManager>();
        canDash = true;
    }

    void Update()
    {
        if ((Movement.moveInput != 0) && canDash && Input.GetKeyDown(KeyCode.C) && !isDashing && charMang.currentPlayer.name == "King")
        {
            StartCoroutine(Dash());
            canDash = false;
        }
    }

    public void PlayerIsGrounded()
    {
        canDash = true;
    }

    private IEnumerator Dash()
    {
        Vector3 dashPosition = this.transform.position + new Vector3(range, 0, 0) * Movement.moveInput;
        isDashing = true;
        remainingTime = maxDashTime;
        while (this.transform.position != dashPosition && remainingTime > 0)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, dashPosition, dashSpeed);
            remainingTime -= Time.deltaTime;
            yield return null;
        }
        isDashing = false;
    }
}