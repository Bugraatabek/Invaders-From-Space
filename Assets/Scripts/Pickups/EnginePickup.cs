using UnityEngine;
public class EnginePickup : Pickup 
{
    public override void CollisionEffect(GameObject other)
    {
        base.CollisionEffect(other);
        EngineManager engineManager = other.GetComponent<EngineManager>();
        engineManager.IncreaseEngineLevel();
        PickupAnimationSpawner.instance.SpawnPickupAnimation($"Engine Level: {engineManager.GetEngineLevel()}");
    } 
}