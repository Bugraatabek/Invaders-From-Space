using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    private const float MAX_LEFT = -6;
    private float _speed = 5f; 
    private bool shouldMove = false;

    private void OnEnable() 
    {
        shouldMove = true;
    }

    private void FixedUpdate() 
    {
        if(!shouldMove) return;
        transform.Translate(Vector2.left * Time.deltaTime * _speed);
        
        if(transform.position.x <= -(LevelBoundry.width + 2))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable() 
    {
        shouldMove = false;
    }
}
