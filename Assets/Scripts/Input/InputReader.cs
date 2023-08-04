using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public static InputReader instance;
    private float speed = 3f;

    public event Action shoot,moveRight, moveLeft, switchGuns;
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
        
        // if(Input.GetKey(KeyCode.R))
        // {
        //     SwitchGuns();
        // }
#endif
    }

    // private void SwitchGuns()
    // {
    //     switchGuns?.Invoke();
    // }

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
