using UnityEngine;

public class HealthPickup : Pickup 
{
    [SerializeField] private int _healAmount;
    public override void CollisionEffect(GameObject other)
    {
        other.GetComponent<Health>().Heal(_healAmount);
        base.CollisionEffect(other);
        PickupAnimationSpawner.instance.SpawnPickupAnimation($"Healed: {_healAmount}");
    }
}