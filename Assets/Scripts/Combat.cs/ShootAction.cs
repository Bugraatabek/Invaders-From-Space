using UnityEngine;

[RequireComponent(typeof(Equipment))]
public class ShootAction : MonoBehaviour 
{
    private Equipment _equipment;
    private Gun _gun;
    private PlayerController _playerController;

    private void Awake() 
    {
        _playerController = GetComponent<PlayerController>();
        _equipment = GetComponent<Equipment>();
        _gun = _equipment.GetGun();
    }

    private void OnEnable() 
    {
        _playerController.shoot += Shoot;
    }

    private void OnDisable() 
    {
        _playerController.shoot -= Shoot;
    }

    public void Shoot()
    {
        if(!_gun) 
        {
            print("Gun is not equiped");
            return;
        }
        _gun.Shoot();
    }
}