using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour {

    public int level;
    public GameObject loadingScreen;

    void Update()
    {
        StartCoroutine(LoadAsync(level));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        yield return new WaitForSeconds(8);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            yield return null;
        }
    }
}
