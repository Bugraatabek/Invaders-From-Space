using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShootHandler : MonoBehaviour
{
    [SerializeField] private float cooldown = 3f;
    private float _shootTimer = 3f;
    
    void Start()
    {
        _shootTimer = cooldown;
        SetBulletPools();
    }

    void Update()
    {
        if(_shootTimer <= 0)
        {
            CommandShoot();
        }
        _shootTimer -= Time.deltaTime;
    }

    private void CommandShoot()
    {
        if(AlienList.Instance.GetListCount() <= 0) return;
        Alien alien = AlienList.Instance.GetListedGameObject(UnityEngine.Random.Range(0, AlienList.Instance.GetListCount()));
        if(alien.IsDead()) return;
        
        alien.Shoot();

        _shootTimer = cooldown;
    }

    public void SetBulletPools()
    {
        print("Setting Bullet Pools");
        for (int i = 0; i < AlienList.Instance.GetListCount(); i++)
        {
            print("i am inside the loop");
            Clip alienClip = AlienList.Instance.GetListedGameObject(i).GetComponent<Clip>();
            alienClip.SetBulletPool(GameManager.instance.GetBulletPool(alienClip.GetBulletType()));
        }
    }
}


