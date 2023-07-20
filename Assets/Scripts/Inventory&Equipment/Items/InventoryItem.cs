using UnityEngine;

[CreateAssetMenu(menuName = "Items/InventoryItem")]
public class InventoryItem : ScriptableObject 
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemImage;
    [SerializeField] private string description;

    public virtual Sprite GetImage()
    {
        return itemImage;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public string GetItemDescription()
    {
        return description;
    }
}