using UnityEngine;

public class CoinPickup : Pickup 
{
    [SerializeField] private int _coinAmount;
    public override void CollisionEffect(GameObject other)
    {
        base.CollisionEffect(other);
        Purse.instance.IncreaseCoins(_coinAmount);
    }    
}