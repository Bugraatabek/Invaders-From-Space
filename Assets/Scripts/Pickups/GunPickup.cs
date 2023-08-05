using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : Pickup
{
    [SerializeField] EGunType gunType;
    [SerializeField] int bulletAmount;
    [SerializeField] string gunName;

    public override void CollisionEffect(GameObject other)
    {
        base.CollisionEffect(other);
        other.GetComponent<Shooter>().SetGun(gunType, bulletAmount);
        PickupAnimationSpawner.instance.SpawnPickupAnimation($"{gunName}, + {bulletAmount} Bullets");
    } 
}
