using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    IDealWithCollision iGetEffectedOnCollision = null;

    private void Awake() 
    {
        iGetEffectedOnCollision = GetComponent<IDealWithCollision>();
    }

    public virtual void OnTriggerEnter2D(Collider2D other) 
    {
        iGetEffectedOnCollision.CollisionEffect(other.gameObject);
    }
}
