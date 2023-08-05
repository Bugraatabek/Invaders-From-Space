using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Life : MonoBehaviour 
{
    public event Action<int> observeLives;
    
    [SerializeField] private int maxLifes;
    [SerializeField] private AudioClip lifeLostSFX;
    private Health health;
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
        observeLives?.Invoke(currentLifes);
    }

    private void UpdateLife()
    {
        currentLifes --;
        AudioPlayer.instance.PlayAudio(lifeLostSFX);
        observeLives?.Invoke(currentLifes);
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
        observeLives?.Invoke(currentLifes);
    }
}