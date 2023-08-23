using System;
using UnityEngine;

public class Shooter : MonoBehaviour 
{
    private Gun _gun;
    private Gun _defaultGun;
    [SerializeField] private Gun[] guns;

    public event Action<Gun> observeGun;

    private void Awake() 
    {
        _defaultGun = GetComponent<Gun>();
        _gun = _defaultGun;
    }

    private void Start() 
    {
        InputReader.instance.shoot += Shoot;
        observeGun?.Invoke(_gun);
    }

    private void Update()
    {
        if ((_gun.GetCurrentAmmoCount() <= 0) && _gun != _defaultGun)
        {
            SetGun(_defaultGun.GetGunType(), 100);
            print("Ammo is zero will now change to default");
        }
    }

    private void OnDisable() 
    {
        InputReader.instance.shoot -= Shoot;
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

    public void SetGun(EGunType gunType, int bulletsToAdd)
    {
        if(gunType == EGunType.Default) 
        {
            _gun = _defaultGun;
            _gun.AddBullets(bulletsToAdd);
            print("Gun is set to Default");
        }

        foreach (var gun in guns)
        {
            if(gun.GetGunType() == gunType)
            {
                gun.gameObject.SetActive(true);
                gun.AddBullets(bulletsToAdd);
                _gun = gun;
            }
            else
            {
                gun.gameObject.SetActive(false);
            }
        }
        observeGun?.Invoke(_gun);
    }
}