using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int highScore;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI highScoreText;

    private void OnEnable()
    {
        PlayerController.onPlayerPass += IncrementScore;
        PlayerController.onPlayerDie += ResetScore;
    }
    private void OnDisable()
    {
        PlayerController.onPlayerPass -= IncrementScore;
        PlayerController.onPlayerDie -= ResetScore;
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
