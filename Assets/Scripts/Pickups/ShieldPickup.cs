using UnityEngine;

public class ShieldPickup : Pickup 
{
    public override void CollisionEffect(GameObject other)
    {
        base.CollisionEffect(other);
        other.GetComponent<ShieldManager>().ActivateRandomShield();
    }
}