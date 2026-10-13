using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;

    public int levelScore = 0;
    public int score = 0;
    void Start()
    {
        scoreText.text = levelScore.ToString();
    }

    private void Awake()
    {
        instance = this;
    }

    public void addPoint()
    {
        levelScore += 1;
        scoreText.text = levelScore.ToString();
    }

    public void resetPoints()
    {
        score = 0;
        scoreText.text = levelScore.ToString();
    }
}
