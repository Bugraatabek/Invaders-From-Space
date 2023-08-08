using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputReader : MonoBehaviour
{
    public static InputReader instance;
    public event Action shoot,moveRight, moveLeft;
    
    [SerializeField] private Button shootButton;
    private float speed = 3f;
    private float dirx;

    private void Awake() 
    {
        if(instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }   
    }
    private void OnEnable() 
    {
        shootButton.onClick.AddListener(() => Shoot());
    }
   
    private void Update() 
    {
#if UNITY_EDITOR
        if(Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if(Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if(Input.GetKey(KeyCode.Space) )
        {
            Shoot();
        }
#endif
        dirx = Input.acceleration.x;
        if(dirx <= -0.1f)
        {
            MoveLeft();
        }
        if(dirx >= 0.1f)
        {
            MoveRight();
        }
    }
    private void Shoot()
    {
        shoot?.Invoke();
    }

    private void MoveLeft()
    {
        moveLeft?.Invoke();
    }

    private void MoveRight()
    {
        moveRight?.Invoke();
    }
}
