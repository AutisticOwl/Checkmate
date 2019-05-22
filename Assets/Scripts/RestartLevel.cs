using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour {

    public int level;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(LoadAsync(level));
        }
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
