using System.Collections.Generic;
using UnityEngine;

public class CollisionHandlerWithTags : CollisionHandler 
{
    [SerializeField] private List<string> tagsToCheck = new List<string>();
    
    public override void OnCollision(Collider2D other)
    {
        if(tagsToCheck.Contains(other.gameObject.tag))
        {
            base.OnCollision(other);
        }
    }
}