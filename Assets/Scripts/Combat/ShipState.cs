using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipState : MonoBehaviour
{
    Health playerHealth;
    [SerializeField] private Sprite[] shipStates;
    private SpriteRenderer _spriteRenderer;

    private float maxHealth = 0;

    private void Awake() 
    {
        playerHealth = GetComponent<Health>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() 
    {
        playerHealth.observeCurrentHealth += UpdateShipState;
    }

    private void OnDisable()
    {
        playerHealth.observeCurrentHealth -= UpdateShipState;
    }

    private void UpdateShipState(int currentHealth)
    {
        if(maxHealth == 0)
        {
            maxHealth = (float)currentHealth;
        }

        float healthPercentage = (currentHealth/maxHealth * 100);
        if(healthPercentage <= 25)
        {
            _spriteRenderer.sprite = shipStates[3];
            return;
        }

        if(healthPercentage <= 50)
        {
            _spriteRenderer.sprite= shipStates[2];
            return;
        }

        if(healthPercentage <= 75)
        {
            _spriteRenderer.sprite = shipStates[1];
            return;
        }

        if(healthPercentage > 75)
        {
            _spriteRenderer.sprite = shipStates[0];
            return;
        }
    }
}
