using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3f;
    public event Action shoot;

    private void FixedUpdate() 
    {
#if UNITY_EDITOR
        if(Input.GetKey(KeyCode.A) && transform.position.x > -LevelBoundry.widthForPlayer)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        if(Input.GetKey(KeyCode.D) && transform.position.x < LevelBoundry.widthForPlayer)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
#endif    
    }

    private void Shoot()
    {
        shoot?.Invoke();
    }
}
