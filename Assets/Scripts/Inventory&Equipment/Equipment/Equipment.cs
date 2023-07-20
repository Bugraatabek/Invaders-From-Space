using System;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour 
{
    public static Equipment Instance;
    [SerializeField] private Gun _gun;
    [SerializeField] private EquipmentSlot[] equipmentSlots;
    private float _cooldown = 1f;
    private float _cooldownTimer = Mathf.Infinity;

    public event Action onGunChange;

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

    private void Update() 
    {
        _cooldownTimer += Time.deltaTime;
    }

    public Gun GetGun()
    {
        return _gun;
    }

    public EquipableItem GetWeapon()
    {
        foreach (var slot in equipmentSlots)
        {
            if(slot.GetEquipLocation() == EquipLocation.Weapon)
            {
                return slot.GetItemInSlot();
            }
        }
        return null;
    }

    public EquipableItem GetArmor()
    {
        foreach (var slot in equipmentSlots)
        {
            if(slot.GetEquipLocation() == EquipLocation.Armor)
            {
                return slot.GetItemInSlot();
            }
        }
        return null;
    }

    public EquipmentSlot[] GetEquipmentSlots()
    {
        return equipmentSlots;
    }


    // private void OnEnable() 
    // {
    //     InputReader.switchGuns += ChangeGun;
    // }

    // private void OnDisable() 
    // {
    //     InputReader.switchGuns -= ChangeGun;
    // }

    
    // private void ChangeGun()
    // {
    //     if(_cooldownTimer < _cooldown) return;
    //     print("changing gun");
    //     Gun[] guns = Resources.LoadAll<Gun>("");
    //     for (int i = 0; i < guns.Length; i++)
    //     {
    //         Gun gunInstance = Spawner.Spawn(guns[i].gameObject, Vector3.zero).GetComponent<Gun>();
    //         _gun = gunInstance;
    //         onGunChange?.Invoke();
    //         _cooldownTimer = 0;
    //     }
        
    // }
}