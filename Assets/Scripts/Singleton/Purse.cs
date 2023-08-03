using System;
using UnityEngine;

public class Purse : MonoBehaviour 
{
       
    public static Purse instance;

    public event Action onCollectCoin;

    [SerializeField] private int _coins;
    public int Coins{ get { return _coins; } }
    
    
    private void Awake() 
    {
        if(instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void IncreaseCoins(int amount)
    {
        _coins += amount;
        onCollectCoin.Invoke();
    }
}