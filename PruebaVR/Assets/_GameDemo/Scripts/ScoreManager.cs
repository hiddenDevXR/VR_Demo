using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    string filePath;
    private static string s_filePath;

    [SerializeField]
    TMPro.TMP_Text[] sessionScores;
    [SerializeField]
    TMPro.TMP_Text sessionTime;

    private static List<ScoreElement> topScores = new List<ScoreElement>();
    private List<float> publicScores = new List<float>();
    private static int scoreMaxCount = 10;

    void Start()
    {
        s_filePath = filePath;
        LoadScores();
    }

    void LoadScores()
    {
        topScores = FileHandler.ReadListFromJSON<ScoreElement>(filePath);

        while (topScores.Count > scoreMaxCount)
            topScores.RemoveAt(scoreMaxCount);
        
        //SanitizeData();

        for (int i = 0; i < topScores.Count; i++)
            sessionScores[i].text = topScores[i].sessionScore.ToString() + "pts";

        sessionTime.text = GameManager.sessionTime.ToString() + "s";
    }

    private void SanitizeData()
    {
        float currentScore = 0;

        foreach (ScoreElement a in topScores)
        {
            currentScore = a.sessionScore;

            foreach (ScoreElement b in topScores)
            {
                if (a != b)
                {
                    if (currentScore == b.sessionScore)
                        b.sessionScore = 0;
                }
            }
        }

        foreach(ScoreElement a in topScores)
        {
            publicScores.Add(a.sessionScore);
        }

        publicScores.Sort();
    }

    private static void SaveScore()
    {
        FileHandler.SaveToJSON<ScoreElement>(topScores, s_filePath);
    }

    public static void ManageScores(ScoreElement element)
    {
        for (int i = 0; i < scoreMaxCount; i++)
        {
            if(i >= topScores.Count || element.sessionScore > topScores[i].sessionScore)
            {
                topScores.Insert(i, element);

                while (topScores.Count > scoreMaxCount)
                    topScores.RemoveAt(scoreMaxCount);

                SaveScore();

                break;
            }
        }   
    }
}
