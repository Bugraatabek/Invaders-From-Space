using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    [SerializeField] Life playerLives;
    [SerializeField] private Image[] lifeSprites;
    private void Awake() 
    {
        playerLives = GameObject.FindWithTag("Player").GetComponent<Life>();
    }

    private void OnEnable() 
    {
        playerLives.observeLives += UpdateUI;
    }

    private void OnDisable() {
        playerLives.observeLives -= UpdateUI;
    }

    private void UpdateUI(int currentLives)
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
}
