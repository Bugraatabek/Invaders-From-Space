using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    IDealWithCollision IDealWithCollision = null;

    private void Awake() 
    {
        IDealWithCollision = GetComponent<IDealWithCollision>();
    }

    public virtual void OnTriggerEnter2D(Collider2D other) 
    {
        IDealWithCollision.CollisionEffect(other.gameObject);
    }
}
