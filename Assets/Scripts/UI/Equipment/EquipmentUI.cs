using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour 
{
    [SerializeField] EquipmentSlotUI armorSlot;
    [SerializeField] EquipmentSlotUI weaponSlot;

    private void Start() 
    {
        //SetupUI();
    }

    private void SetupUI()
    {
        foreach (EquipmentSlot equipmentSlot in Equipment.Instance.GetEquipmentSlots())
        {
            if(equipmentSlot.GetEquipLocation() == EquipLocation.Weapon)
            {
                weaponSlot.SetupUI(equipmentSlot.GetItemInSlot().GetImage(), EquipLocation.Weapon);
            }
            if(equipmentSlot.GetEquipLocation() == EquipLocation.Armor)
            {
                weaponSlot.SetupUI(equipmentSlot.GetItemInSlot().GetImage(), EquipLocation.Armor);
            }
        }
    }
}