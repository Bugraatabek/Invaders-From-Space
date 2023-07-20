using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour 
{
    [SerializeField] EquipLocation equipLocation;
    Image itemImage;
    EquipableItem equipableItem;

    public bool SetItemInSlot(EquipableItem itemToEquip)
    {
        if(this.equipLocation != itemToEquip.GetEquipLocation()) return false;
        equipableItem = itemToEquip;
        itemImage.sprite = itemToEquip.GetImage(); 
        return true;
    }

    public EquipableItem GetItemInSlot()
    {
        return equipableItem;
    }

    public EquipLocation GetEquipLocation()
    {
        return equipLocation;
    }
}