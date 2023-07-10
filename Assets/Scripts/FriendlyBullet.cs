using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBullet : MonoBehaviour
{
    private float speed = 10f;
    private bool shouldTravel;
    
    private void OnEnable() 
    {
        shouldTravel = true;
    }
    
    private void Update() 
    {
        if(!shouldTravel) return;
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    private void OnDisable() 
    {
        shouldTravel = false;
    }
}
