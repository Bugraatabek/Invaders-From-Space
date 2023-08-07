using System;
using UnityEngine;

public class Shooter : MonoBehaviour 
{
    private Gun _gun;
    [SerializeField] private Gun[] guns;

    public event Action<Gun> observeGun;

    private void Awake() 
    {
        _gun = GetComponent<Gun>();
    }

    private void Start() 
    {
        InputReader.instance.shoot += Shoot;
        observeGun?.Invoke(_gun);
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
        foreach (var gun in guns)
        {
            if(gun.GetGunType() == gunType)
            {
                gun.gameObject.SetActive(true);
                gun.AddBullets(bulletsToAdd);
                _gun = gun;
                observeGun?.Invoke(_gun);
            }
            else
            {
                gun.gameObject.SetActive(false);
            }
        }
    }
}