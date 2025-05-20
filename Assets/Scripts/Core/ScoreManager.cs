using UnityEngine;
using System;
using Scripts.Core.EventSystem;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int highScore;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI highScoreText;

    private void OnEnable()
    {
        EventBus.OnPipePassed += IncrementScore;
    
    }
    private void OnDisable()
    {
        EventBus.OnPipePassed -= IncrementScore;
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        // highScoreText.text = highScore.ToString();
    }
    void IncrementScore()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    void ResetScore()
    {
        score = 0;
    }
}
