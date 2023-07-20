using UnityEngine;

[RequireComponent(typeof(Equipment))]
public class Shooter : MonoBehaviour 
{
    private Equipment _equipment;
    private Gun _gun;

    private void Awake() 
    {
        _equipment = GetComponent<Equipment>();
        _gun = _equipment.GetGun();
    }

    private void OnEnable() 
    {
        InputReader.shoot += Shoot;
    }

    private void OnDisable() 
    {
        InputReader.shoot -= Shoot;
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