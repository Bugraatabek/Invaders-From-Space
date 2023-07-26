using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, IDealWithCollision
{
    [SerializeField] private float _travelSpeed;

    private void Update() 
    {
        Travel();
    }

    public virtual void CollisionEffect(GameObject other)
    {
        gameObject.SetActive(false);
    }

    private void Travel()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _travelSpeed);
    }
}