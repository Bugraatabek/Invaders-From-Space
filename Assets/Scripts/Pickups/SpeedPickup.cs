using UnityEngine;

public class SpeedPickup : Pickup 
{
    [SerializeField] private float _speedAmount;
    public override void CollisionEffect(GameObject other)
    {
        other.GetComponent<Mover>().IncreaseSpeed(_speedAmount);
        base.CollisionEffect(other);
    }
}