using UnityEngine;

public class Mover : MonoBehaviour 
{
    [SerializeField] private float speed = 3;
    private void OnEnable() 
    {
        InputReader.moveLeft += MoveLeft;
        InputReader.moveRight += MoveRight;
    }

    private void OnDisable() 
    {
        InputReader.moveLeft -= MoveLeft;
        InputReader.moveRight -= MoveRight;
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
}