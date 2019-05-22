using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject loadingScreen;
    public GameObject Pausemenu;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Pausemenu.SetActive(true);
            Cursor.visible = true;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Pausemenu.SetActive(false);
        Cursor.visible = false;
    }

    public void Quit()
    {
        Cursor.visible = true;
        StartCoroutine(LoadAsync(0));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
