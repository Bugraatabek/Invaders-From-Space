using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private AudioClip hitSFX;
    
    private int currentHealth;
   
    public event Action onDeath;
    public event Action onHealthChange;
    public event Action<int> observeCurrentHealth;


    private void Awake() 
    {
        currentHealth = maxHealth;
    }

    private void Start() 
    {
        observeCurrentHealth?.Invoke(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        AudioPlayer.instance.PlayAudio(hitSFX);
        damage = Math.Abs(damage);

        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
        onHealthChange?.Invoke();
        observeCurrentHealth?.Invoke(currentHealth);

        if(currentHealth <= 0)
        {
            currentHealth = maxHealth;
            observeCurrentHealth?.Invoke(currentHealth);
            onDeath?.Invoke();
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetFraction()
    {
        return ((float)currentHealth / (float)maxHealth);
    }

    public void Heal(int amount)
    {
        amount = Math.Abs(amount);
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        onHealthChange?.Invoke();
        observeCurrentHealth?.Invoke(currentHealth);
        
    }
}