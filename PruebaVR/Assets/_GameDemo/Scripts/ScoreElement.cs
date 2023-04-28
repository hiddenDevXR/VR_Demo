using System;

[Serializable]
public class ScoreElement
{
    public float sessionScore;

    public ScoreElement(float sessionScore)
    {
        this.sessionScore = sessionScore;
    }
}
