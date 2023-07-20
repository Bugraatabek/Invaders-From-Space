using UnityEngine;

public class EquipableItem : InventoryItem 
{
    [SerializeField] private EquipLocation equipLocation;

    public EquipLocation GetEquipLocation()
    {
        return equipLocation;
    }
}