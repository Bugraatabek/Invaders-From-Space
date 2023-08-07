using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    [SerializeField] Life playerLives;
    [SerializeField] TextMeshProUGUI lifeText;

    private void OnEnable() 
    {
        playerLives.observeLives += UpdateUI;
    }

    private void OnDisable() {
        playerLives.observeLives -= UpdateUI;
    }

    private void UpdateUI(int currentLives)
    {
        lifeText.text = $"Life: {currentLives}";
    }
}
