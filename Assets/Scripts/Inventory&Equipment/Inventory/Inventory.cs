using System;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
    public static Inventory Instance;
    
    public int CurrentCoinsCount {get {return _coins;}}

    [SerializeField] InventorySlot[] slots;
    [SerializeField] private int _coins;
    

    private void Awake() 
    {
        if(Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}