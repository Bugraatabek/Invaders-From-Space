using System;
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI bulletText;

    [SerializeField] Clip clip;

    private void OnEnable() 
    {
        clip.observeBullets += UpdateUI;
    }

    private void UpdateUI(int currentBullets)
    {
        bulletText.text = currentBullets.ToString();
    }
}