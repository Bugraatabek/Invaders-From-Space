using UnityEngine;

public class InventorySlot : MonoBehaviour 
{
    InventoryItem item;

    public void SetItemInSlot(InventoryItem inventoryItem)
    {
        this.item = inventoryItem;
    }

    public InventoryItem GetItemInSlot()
    {
        return item;
    }
}