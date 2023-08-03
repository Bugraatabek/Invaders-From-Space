using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour 
{
    public Sprite[] healthBars;
    public Image healthBar;
    
    Health playerHealth;
    private void Awake() 
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
    }

    private void Start() 
    {
        playerHealth.observeCurrentHealth += UpdateUI;
    }

    public void UpdateUI(int currentHealth)
    {
        healthBar.sprite = healthBars[currentHealth];
    }
}