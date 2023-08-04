using System;
using UnityEngine;

public class Mover : MonoBehaviour 
{
    [SerializeField] private float speed = 3;
    public event Action<float> observeSpeed;
    
    private void Start() 
    {
        observeSpeed?.Invoke(speed);
        InputReader.instance.moveLeft += MoveLeft;
        InputReader.instance.moveRight += MoveRight;
    }
    

    private void OnDisable() 
    {
        InputReader.instance.moveLeft -= MoveLeft;
        InputReader.instance.moveRight -= MoveRight;
    }

    private void MoveRight()
    {
        if(transform.position.x < LevelBoundry.width - 0.25f)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
    }

    private void MoveLeft()
    {
        if(transform.position.x > -(LevelBoundry.width - 0.25f))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
    }

    public void SetSpeed(float speedAmount)
    {
        speed = speedAmount;
        observeSpeed?.Invoke(speed);
    }
}