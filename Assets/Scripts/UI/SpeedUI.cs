using System;
using TMPro;
using UnityEngine;

public class SpeedUI : MonoBehaviour 
{
    [SerializeField] Mover playerMover;
    [SerializeField] TextMeshProUGUI speedText;

    private void Start() 
    {
        playerMover.observeSpeed += UpdateUI;
    }

    private void UpdateUI(float speed)
    {
        speedText.text = $"Speed: {speed}";
    }

    private void OnDisable()
    {
        playerMover.observeSpeed -= UpdateUI;
    }
}