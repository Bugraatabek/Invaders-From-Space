using System;
using UnityEngine;

public class Health : MonoBehaviour,IGetEffectedOnCollision
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int maxLifes;
    private int currentHealth;
    private int currentLifes;


    public static event Action onDeath;


    private void Awake() 
    {
        currentHealth = maxHealth;
        currentLifes = maxLifes;
    }

    public void CollisionEffect()
    {
        TakeDamage(-1);
    }

    public void TakeDamage(int damage)
    {
        currentHealth += damage;
        if(currentHealth <= 0)
        {
            currentLifes -= 1;
            if(currentLifes <= 0)
            {
                onDeath?.Invoke();
                print("You're dead, game is over.");
            }
        }
    }
}