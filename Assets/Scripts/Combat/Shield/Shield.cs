using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Shield : MonoBehaviour
{
    protected Health health;
    protected bool isDead = false;
    
    protected virtual void Awake() 
    {
        health = GetComponent<Health>();
    }

    private void OnEnable() 
    {
        health.onTakeDamage += UpdateShield;
    }

    private void OnDisable() 
    {
        health.onTakeDamage -= UpdateShield;
    }

    protected virtual void UpdateShield()
    {
        if(health.GetCurrentHealth() <= 0)
        {
            gameObject.SetActive(false);
            isDead = true;
            return;
        }
    }

    public void ResetShield()
    {
        health.Heal(50);
    }
}
