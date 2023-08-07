using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathUI : MonoBehaviour
{
    [SerializeField] Button playAgain, exit;
    [SerializeField] Life playerLife;
    [SerializeField] RectTransform panel;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] ScoreUI scoreUI;
    
    void Start()
    {
        playAgain.onClick.AddListener(() => PlayAgain());
        exit.onClick.AddListener(() => Exit());
        playerLife.onDeath += StartUI;
    }

    private void StartUI()
    {
        panel.gameObject.SetActive(true);
        scoreText.text = $"Your Score: {scoreUI.GetScore()}";
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
