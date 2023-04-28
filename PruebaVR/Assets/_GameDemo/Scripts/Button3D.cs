using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button3D : MonoBehaviour
{
    public static bool selectionEnable;
    public enum Type { PLAY, EXIT };
    public Type type;

    void Start()
    {
        selectionEnable = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(selectionEnable)
        {
            if (type == Type.PLAY)
                SceneManager.LoadScene(1);

            else if (type == Type.EXIT)
                Application.Quit();

            selectionEnable = false;
        }
    }
}
