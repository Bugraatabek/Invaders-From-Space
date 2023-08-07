using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour 
{
    [SerializeField] Health playerHealth;
    [SerializeField] private TextMeshProUGUI healthText;

    private void OnEnable() 
    {
        playerHealth.observeCurrentHealth += UpdateUI;
    }

    private void OnDisable()
    {
        playerHealth.observeCurrentHealth -= UpdateUI;
    }

    public void UpdateUI(int currentHealth)
    {
        healthText.text = $"Health: {currentHealth}";
    }
}