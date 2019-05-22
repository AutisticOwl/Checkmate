using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentPlatformTimed : MonoBehaviour {

    public GameObject Transparent;
    private bool isSolid = false;

    void Start()
    {
        StartCoroutine(Timer());
    }

    void Update()
    {
        Transparent.SetActive(isSolid);
        GetComponent<BoxCollider2D>().enabled = !isSolid;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        isSolid = !isSolid;
        StartCoroutine(Timer());
    }
}
