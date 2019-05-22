using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterNextLevel : MonoBehaviour {

    public int level;
    public GameObject loadingScreen;

    void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "King")
        {
            Movement move = Player.GetComponent<Movement>();
            move.speed = 0;
            move.jumpForce = 0;
            CharacterManager.objectiveReached = true;
            StartCoroutine(LoadAsync(level));
        }
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        yield return new WaitForSeconds(2);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
