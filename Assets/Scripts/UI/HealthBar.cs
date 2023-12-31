using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Canvas rootCanvas;
    [SerializeField] Health healthComponent;
    [SerializeField] RectTransform foreground;

    private void Start() 
    {
        UpdateUI();   
    }

    private void OnEnable() 
    {
        healthComponent.onHealthChange += UpdateUI;
    }

    private void OnDisable() 
    {
        healthComponent.onHealthChange -= UpdateUI;
    }

    private void UpdateUI()
    {
        foreground.localScale = new Vector3(healthComponent.GetFraction(), 1, 1);
    }
}
