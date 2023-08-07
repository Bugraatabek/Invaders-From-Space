using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Shield : MonoBehaviour
{
    private Health health;
    private bool isDead = false;
    [SerializeField] EShieldType shieldType;
    
    protected virtual void Awake() 
    {
        health = GetComponent<Health>();
    }

    private void OnEnable() 
    {
        health.onHealthChange += UpdateShield;
    }

    private void OnDisable() 
    {
        health.onHealthChange -= UpdateShield;
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

    public EShieldType GetShieldType()
    {
        return shieldType;
    }
}
