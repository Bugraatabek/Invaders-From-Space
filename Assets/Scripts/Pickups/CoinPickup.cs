using UnityEngine;

public class CoinPickup : Pickup 
{
    [SerializeField] private int _coinAmount;
    public override void CollisionEffect(GameObject other)
    {
        other.GetComponent<Purse>().IncreaseCoins(_coinAmount);
        base.CollisionEffect(other);
    }    
}