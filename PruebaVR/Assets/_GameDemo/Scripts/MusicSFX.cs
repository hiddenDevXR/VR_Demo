using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSFX : MonoBehaviour
{
    private static MusicSFX instance = null;
    public static MusicSFX Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (MusicSFX)FindObjectOfType(typeof(MusicSFX));
            }
            return instance;
        }
    }

    void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
