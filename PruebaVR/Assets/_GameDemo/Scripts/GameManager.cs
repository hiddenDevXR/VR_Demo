using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool enableTimeUpdate = true;
    public static float sessionTime = 0f;
    public static float sessionScore = 0f;

    void Start()
    {
        sessionScore = 0f;
        sessionTime = 0f;
        CubesPool.IsEmpty += OnPoolEmptied;
    }

    void Update()
    {
        if(enableTimeUpdate)
            sessionTime += Time.deltaTime;
    }

    void OnPoolEmptied()
    {
        CubesPool.IsEmpty -= OnPoolEmptied;
        enableTimeUpdate = false;      
        ScoreManager.ManageScores(new ScoreElement(sessionScore));
        SceneManager.LoadScene(0);
    }
}
