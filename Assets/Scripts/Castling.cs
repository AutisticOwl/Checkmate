using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Castling : MonoBehaviour {

    private CharacterManager charMang;
    public GameObject CastlingUI;
    public GameObject CastlingCross;
    private bool canUse = true;
    Movement king = null;
    Movement rook = null;
    Vector3 kingPos;
    Vector3 rookPos;

    public void Start()
    {
        charMang = FindObjectOfType<CharacterManager>();
        rook = FindObjectsOfType<Movement>().Where(x => x.tag == "Rook").First();
        king = FindObjectsOfType<Movement>().Where(x => x.tag == "King").First();
    }

    public void Update()
    {
        if (charMang.currentPlayer.name == "King")
        {
            CastlingUI.SetActive(true);
        }
        else
        {
            CastlingUI.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.V) && canUse == true && name == "King" && charMang.currentPlayer.name == "King")
        {
            foreach (Movement mvmt in CharacterController.FindObjectOfType<CharacterManager>().players)
            {
                if (mvmt.gameObject.tag == "Rook")
                {
                    rookPos = rook.transform.position;
                }
                else if (mvmt.gameObject.tag == "King")
                {
                    kingPos = king.transform.position;
                }
            }
            CastlingCross.SetActive(true);
            king.transform.position = rookPos;
            rook.transform.position = kingPos;
            StartCoroutine(rook.EnableForSecs(1));
            canUse = false;
        }
	}
}
