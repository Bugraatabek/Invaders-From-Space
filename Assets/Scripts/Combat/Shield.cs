using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Shield : MonoBehaviour
{
    [SerializeField] private Sprite[] states;
    Health health;
    private SpriteRenderer spriteRenderer;

    private void Awake() 
    {
        health = GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() 
    {
        health.onTakeDamage += UpdateSprite;
    }

    private void OnDisable() 
    {
        health.onTakeDamage -= UpdateSprite;
    }
    
    public void UpdateSprite()
    {
        if (health.GetCurrentHealth() <= 0) 
        { 
            Destroy(gameObject);
            return;
        }
        spriteRenderer.sprite = states[(int)health.GetCurrentHealth() - 1];
    }
}
