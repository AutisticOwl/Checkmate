using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StompAttackHit : MonoBehaviour {

    private Movement mvmt;

    void Start()
    {
        mvmt = FindObjectOfType<Movement>();
    }

    void OnParticleCollision(GameObject other)
    {
        mvmt.deathEffect.SetActive(true);
        mvmt.sprite.SetActive(false);
        mvmt.speed = 0;
        mvmt.jumpForce = 0;
        StartCoroutine(LoadAsync(mvmt.level));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        yield return new WaitForSeconds(2);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
