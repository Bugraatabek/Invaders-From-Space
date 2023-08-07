using UnityEngine;

public class ShieldPickup : Pickup 
{
    [SerializeField] EShieldType shieldType;
    [SerializeField] string shieldName;
    public override void CollisionEffect(GameObject other)
    {
        base.CollisionEffect(other);
        other.GetComponent<ShieldManager>().ActivateShield(shieldType);
        PickupAnimationSpawner.instance.SpawnPickupAnimation($"{shieldName}");
    }
}