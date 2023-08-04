using System;
using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI damageText;
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI gunText;

    [SerializeField] Shooter shooter;
    [SerializeField] Mover mover;

    private void OnEnable() 
    {
        mover.observeSpeed += UpdateSpeed;
        shooter.observeGun += UpdateGun;
    }

    private void UpdateGun(Gun gun)
    {
        gunText.text = gun.GetGunType().ToString();
        UpdateDamage(gun.GetDamage());
    }

    private void UpdateDamage(int damage)
    {
        damageText.text = damage.ToString();
    }

    
    private void UpdateSpeed(float speed)
    {
        speedText.text = speed.ToString();
    }

    private void OnDisable() 
    {
        mover.observeSpeed -= UpdateSpeed;
        shooter.observeGun -= UpdateGun;
    }
}