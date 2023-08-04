using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private bool isPlayer = false;
    
    private int currentHealth;
   
    public event Action onDeath;
    public event Action onTakeDamage;
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
        damage = Math.Abs(damage);

        currentHealth -= damage;
        onTakeDamage?.Invoke();
        observeCurrentHealth?.Invoke(currentHealth);

        if(currentHealth <= 0)
        {
            currentHealth = maxHealth;
            observeCurrentHealth?.Invoke(currentHealth);
            onTakeDamage?.Invoke();
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
        observeCurrentHealth?.Invoke(currentHealth);
        
    }
}