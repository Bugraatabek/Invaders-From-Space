using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    IGetEffectedOnCollision iGetEffectedOnCollision = null;

    private void Awake() 
    {
        iGetEffectedOnCollision = GetComponent<IGetEffectedOnCollision>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        OnCollision(other);
    }

    public virtual void OnCollision(Collider2D other)
    {
        iGetEffectedOnCollision.CollisionEffect();
    }
}
