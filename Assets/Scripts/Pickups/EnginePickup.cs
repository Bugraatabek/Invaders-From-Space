using UnityEngine;

public class EnginePickup : Pickup 
{
    public override void CollisionEffect(GameObject other)
    {
        base.CollisionEffect(other);
        other.GetComponent<EngineManager>().IncreaseEngineLevel();
    } 
}