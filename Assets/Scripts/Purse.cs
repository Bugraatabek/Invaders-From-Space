using UnityEngine;

public class Purse : MonoBehaviour 
{
    [SerializeField] private int _coins;

    public void IncreaseCoins(int amount)
    {
        _coins += amount;
        PlayerUI.Instance.UpdateCoins(amount);
    }
}