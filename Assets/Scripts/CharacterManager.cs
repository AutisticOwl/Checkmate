using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extensions;

public class CharacterManager : MonoBehaviour
{
    public Movement[] players;
    public Movement currentPlayer { get; private set; }
    private int currentPlayerIndex;
    public GameObject ArrowKing;
    public GameObject ArrowHorse;
    public GameObject ArrowBishop;
    public GameObject ArrowRook;
    public static bool objectiveReached;

    void Start()
    {
        objectiveReached = false;
        players = FindObjectsOfType<Movement>();
        currentPlayerIndex = -1;
        ChangePlayer();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangePlayer();
        }
        if (!objectiveReached)
        {
            players.Where(player => !player.disableSelf).ForEach(player => player.UpdateMe());
        }

        if (currentPlayer.name == "King")
        {
            ArrowKing.SetActive(true);
            ArrowHorse.SetActive(false);
            ArrowBishop.SetActive(false);
            ArrowRook.SetActive(false);
        }

        if (currentPlayer.name == "Horse")
        {
            ArrowHorse.SetActive(true);
            ArrowKing.SetActive(false);
            ArrowBishop.SetActive(false);
            ArrowRook.SetActive(false);
        }

        if (currentPlayer.name == "Bishop")
        {
            ArrowBishop.SetActive(true);
            ArrowKing.SetActive(false);
            ArrowHorse.SetActive(false);
            ArrowRook.SetActive(false);
        }

        if (currentPlayer.name == "Rook")
        {
            ArrowRook.SetActive(true);
            ArrowBishop.SetActive(false);
            ArrowKing.SetActive(false);
            ArrowHorse.SetActive(false);
        }
    }

    public void ChangePlayer()
    {
        currentPlayerIndex++;
        if (currentPlayerIndex >= players.Length)
            currentPlayerIndex = 0;
        currentPlayer = players[currentPlayerIndex];
        FindObjectOfType<CameraMovement>().target = currentPlayer.transform;
        foreach (Movement player in players)
        {
            
            if (player != currentPlayer)
            {
                //player.arrow.SetActive(false);
                player.disableSelf = true;
            }
            else
            {
                //player.arrow.SetActive(true);
                player.disableSelf = false;
                player.GetComponent<BoxCollider2D>().enabled = true;
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
    public void FixedUpdate()
    {
        players.Where(player => !player.disableSelf).ForEach(player => player.FixedUpdateMe());
    }
}
