using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private bool isPlayer = false;
    
    private int currentHealth;
   
    public event Action onDeath;
    public event Action onTakeDamage;

    private void Awake() 
    {
        currentHealth = maxHealth;
    }

    private void Start() 
    {
        if(isPlayer) //Refactor
        {
            PlayerUI.Instance.UpdateHealth(currentHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        damage = Math.Abs(damage);

        currentHealth -= damage;
        onTakeDamage?.Invoke();
        
        if(isPlayer) //Refactor
        {
            PlayerUI.Instance.UpdateHealth(currentHealth);
        }
        

        if(currentHealth <= 0)
        {
            currentHealth = maxHealth;
            if(isPlayer) //Refactor
            {
                PlayerUI.Instance.UpdateHealth(currentHealth);
            }
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
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        if(isPlayer) //Refactor
        {
            PlayerUI.Instance.UpdateHealth(currentHealth);
        }
        
    }
}