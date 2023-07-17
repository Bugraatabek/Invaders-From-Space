using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour,IGetEffectedOnCollision
{
    [SerializeField] private Sprite[] states;
    [SerializeField] private int health;
    private SpriteRenderer spriteRenderer;

    private void Awake() 
    {
        health = 4;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void CollisionEffect()
    {
        health--;
        if (health <= 0) 
        { 
            Destroy(gameObject);
            return;
        }
        spriteRenderer.sprite = states[health - 1];
        
        
    }

    // private void OnTriggerEnter2D(Collider2D other) 
    // {
    //     if(other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("FriendlyBullet"))
    //     {
    //         health--;
    //     }
    // }
}
