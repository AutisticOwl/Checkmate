using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioKeepPlaying : MonoBehaviour {

    private static AudioKeepPlaying instance = null;
    private static AudioKeepPlaying Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
