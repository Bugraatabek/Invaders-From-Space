using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Life : MonoBehaviour 
{
    Health health;
    [SerializeField] private int maxLifes;

    private int currentLifes;
    
    
    private void Awake() 
    {
        health = GetComponent<Health>();
        currentLifes = maxLifes;
    }

    private void OnEnable() 
    {
        health.onDeath += UpdateLife;
    }

    private void OnDisable() 
    {
        health.onDeath -= UpdateLife;
    }

    private void Start()
    {
        PlayerUI.Instance.UpdateLives(currentLifes);
    }

    private void UpdateLife()
    {
        currentLifes --;
        PlayerUI.Instance.UpdateLives(currentLifes);
        if(currentLifes <= 0)
        {
            print("you're dead, game is over");
        }
    }

    public void IncreaseLife(int amount)
    {
        currentLifes += amount;
        if(currentLifes > maxLifes)
        {
            currentLifes = maxLifes;
        }
        PlayerUI.Instance.UpdateLives(currentLifes);
    }
}