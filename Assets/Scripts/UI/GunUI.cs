using System;
using TMPro;
using UnityEngine;

public class GunUI : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI gunText;
    [SerializeField] Shooter shooter;

    private void OnEnable() 
    {
        shooter.observeGun += UpdateGun;
    }

    private void UpdateGun(Gun gun)
    {
        gunText.text = $"Gun: {gun.GetGunName()}";
    }

    private void OnDisable() 
    {
        shooter.observeGun -= UpdateGun;
    }
}