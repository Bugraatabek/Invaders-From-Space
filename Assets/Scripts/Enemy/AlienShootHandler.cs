using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShootHandler : MonoBehaviour
{
    [SerializeField] private float shootTime = 3f;
    [SerializeField] private ObjectPool EnemyBulletobjectPool = null;
    private float _shootTimer = 3f;
    
    void Start()
    {
        _shootTimer = shootTime;
    }

    void Update()
    {
        if(_shootTimer <= 0)
        {
            Shoot();
        }
        _shootTimer -= Time.deltaTime;
    }

    private void Shoot()
    {
        if(AlienList.GetListCount() <= 0) return;
        Vector2 pos = AlienList.GetListedGameObject(UnityEngine.Random.Range(0, AlienList.GetListCount())).transform.position;
        GameObject obj = EnemyBulletobjectPool.GetPooledObject();
        obj.transform.position = pos;
        _shootTimer = shootTime;
    }
}


