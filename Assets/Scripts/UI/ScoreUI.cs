using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour 
{
    public TextMeshProUGUI scoreText;
    private int _score;
    
    private void Start() 
    {
        Alien.scoreIncreased += UpdateUI;
        UpdateUI(0);
    }

    private void UpdateUI(int scoreToIncrease)
    {
        _score += scoreToIncrease;
        scoreText.text = $"Score: {_score}";
    }

    public int GetScore()
    {
        return _score;
    }
}