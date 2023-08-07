using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialUI : MonoBehaviour
{
    [SerializeField] Button startButton, exitButton;
    [SerializeField] RectTransform panel;
    public event Action gameStarted;
    void Start()
    {
        Time.timeScale = 0;
        startButton.onClick.AddListener(() => StartGame());
        exitButton.onClick.AddListener(() => Exit()); 
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        panel.gameObject.SetActive(false);
        gameStarted?.Invoke();
    }

    private void Exit()
    {
        Application.Quit();
    }
}
