using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI highscoreText;
    
    //private readonly int _highscore;
    private int _wave;

    
    //private Color32 _active = new Color(1, 1, 1, 1);
    //private Color32 _inactive = new Color(1, 1, 1, 0.25f);

    //readonly GameObject player;
    
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
    }

    public void UpdateHighScore()
    {

    }

    public void UpdateWave()
    {
        _wave += 1;
        waveText.text = _wave.ToString();
    }
}
