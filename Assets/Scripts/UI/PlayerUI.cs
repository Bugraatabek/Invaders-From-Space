using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI scoreText;

    public Image[] lifeSprites;
    public Image healthBar;
    public Sprite[] healthBars;
    
    private int _score;
    private int _highscore;
    private int _wave;

    
    private Color32 _active = new Color(1, 1, 1, 1);
    private Color32 _inactive = new Color(1, 1, 1, 0.25f);
    
    private void Awake() 
    {
        if(Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        _score = 0;
        UpdateScore(_score);
    }

    public void UpdateHealth(float currentHealth)
    {
        healthBar.sprite = healthBars[((int)currentHealth)];
    }

    public void UpdateLives(int currentLives)
    {
        for (int i = 0; i < lifeSprites.Length; i++)
        {
            lifeSprites[i].enabled = false;
        }

        for (int i = 0; i < currentLives; i++)
        {
            lifeSprites[i].enabled = true;
        }
    }

    public void UpdateScore (int value)
    {
        _score += value;
        scoreText.text = _score.ToString();
    }

    public void UpdateHighScore()
    {

    }

    public void UpdateWave()
    {
        _wave += 1;
        waveText.text = _wave.ToString();
    }

    public void UpdateCoins()
    {
        coinText.text = Inventory.Instance.CurrentCoinsCount.ToString();
    }
}
