using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    public int scoreValue;
    
    private const float MAX_LEFT = -6;
    private float _speed = 5f; 

    private void Update() 
    {
        transform.Translate(Vector2.left * Time.deltaTime * _speed);
        
        if(transform.position.x <= -(LevelBoundry.width + 2))
        {
            gameObject.SetActive(false);
        }
    }
}
