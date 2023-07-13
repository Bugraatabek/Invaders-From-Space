using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour,IGetEffectedOnCollision
{
    [SerializeField] private Sprite[] states;
    [SerializeField] private int health;
    private SpriteRenderer spriteRenderer;

    public void CollisionEffect()
    {
        health--;
        spriteRenderer.sprite = states[health - 1];
        
        if (health <= 0) 
        { 
            Destroy(gameObject);
        }
    }

    // private void OnTriggerEnter2D(Collider2D other) 
    // {
    //     if(other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("FriendlyBullet"))
    //     {
    //         health--;
    //     }
    // }
}
