using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDropper : MonoBehaviour
{
    [SerializeField] DropLibrary dropLibrary;
    [SerializeField] PickupPool pickupPool;
    Pickup[] pickupsToDrop;
    int dropChanceFloor = 0;
    int dropChanceCeiling = 100;
    
    private void Awake() 
    {
        pickupsToDrop = dropLibrary.GetPickups();
    }

    public void DropPickup()
    {
        if(!ShouldDrop()) return;
        Instantiate(ChooseWhichPickupToDrop(), transform.position, Quaternion.identity);
    }
    
    private Pickup ChooseWhichPickupToDrop()
    {
        int diceRoll = Random.Range(0,pickupsToDrop.Length);
        return pickupsToDrop[diceRoll];
    }
    
    private bool ShouldDrop()
    {
        int diceRoll = Random.Range(dropChanceFloor, dropChanceCeiling);
        if(diceRoll <= 80)
        {
            return true;
        }
        return false;
    }
}
