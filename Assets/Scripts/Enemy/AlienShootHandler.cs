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
        if(AlienList.GetListCount() <= 0) return;
        GameObject alien = AlienList.GetListedGameObject(UnityEngine.Random.Range(0, AlienList.GetListCount()));
        alien.GetComponent<Alien>().Shoot();
        
        _shootTimer = cooldown;
    }
}


