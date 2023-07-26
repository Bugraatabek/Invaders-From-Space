using UnityEngine;

public class LifePickup : Pickup 
{
    [SerializeField] private int _lifeAmount;
    public override void CollisionEffect(GameObject other)
    {
        other.GetComponent<Life>().IncreaseLife(_lifeAmount);
        base.CollisionEffect(other);
    }    
}