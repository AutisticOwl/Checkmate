using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class MainMenu : MonoBehaviour {

    public GameObject loadingScreen;
    public GameObject BaseMenu;
    public GameObject PlayMenu;
    public GameObject OptionsMenu;
    public GameObject CreditsMenu;

    public void BeginGame(int sceneIndex)
    {
        Cursor.visible = false;
        StartCoroutine(LoadAsync(sceneIndex));
    }

    public void Play()
    {
        PlayMenu.SetActive(true);
        BaseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    public void Options()
    {
        OptionsMenu.SetActive(true);
        BaseMenu.SetActive(false);
        PlayMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    public void Credits()
    {
        CreditsMenu.SetActive(true);
        BaseMenu.SetActive(false);
        PlayMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    public void Back()
    {
        CreditsMenu.SetActive(false);
        BaseMenu.SetActive(true);
        PlayMenu.SetActive(false);
        OptionsMenu.SetActive(false);
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

    public void ExitGame()
    {
#if (UNITY_EDITOR)
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}