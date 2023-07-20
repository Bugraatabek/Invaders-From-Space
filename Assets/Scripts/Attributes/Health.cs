using System;
using UnityEngine;

public class Health : MonoBehaviour,IGetEffectedOnCollision
{
    [SerializeField] private float maxHealth;
    [SerializeField] private bool isPlayer = false;
    
    private float currentHealth;
   
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

    public void CollisionEffect()
    {
        TakeDamage(-1);
    }

    public void TakeDamage(int damage)
    {
        currentHealth += damage;
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

    public float GetFraction()
    {
        return (currentHealth / maxHealth);
    }
}