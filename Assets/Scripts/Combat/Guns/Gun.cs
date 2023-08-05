using System;
using UnityEngine;

[RequireComponent(typeof(Clip))]
public class Gun : MonoBehaviour
{
    private Clip _clip;
    
    [SerializeField] private EGunType gunType;
    [SerializeField] private float _cooldown;
    [SerializeField] private int _damage;
    [SerializeField] private AudioClip sfx;

    private bool _shouldShoot = true;
    private float cooldownCounter = Mathf.Infinity;

    private void Awake() 
    {
        _clip = GetComponent<Clip>();
    }
    
    private void Update() 
    {
        cooldownCounter += Time.deltaTime;
        if(cooldownCounter < _cooldown)
        {
            _shouldShoot = false;
        }
        else
        {
            _shouldShoot = true;
        }
    }

    public virtual void Shoot()
    {
        if(cooldownCounter < _cooldown) return;
        if(_clip == null)
        {
            print("There is no clip");
            return;
        }
        _clip.GetBullet(_damage);
        AudioPlayer.instance.PlayAudio(sfx);
        cooldownCounter = 0;
    }

    public EGunType GetGunType()
    {
        return gunType;
    }

    public int GetDamage()
    {
        return _damage;
    }

    public void AddBullets(int bulletsToAdd)
    {
        _clip.AddBullets(bulletsToAdd);
    }
}