using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IDealWithCollision
{
    protected Vector2 travelDir;
    
    [SerializeField] private float _travelSpeed = 10f;
    private bool _shouldTravel;
    private int _damageToCarry;
    [SerializeField] EBulletType bulletType;
    
    public virtual void CollisionEffect(GameObject other)
    {
        gameObject.SetActive(false);
        other.GetComponent<Health>().TakeDamage(_damageToCarry);
    }

    public void SetDamage(int damage)
    {
        _damageToCarry = damage;
    }

    private void OnEnable() 
    {
        _shouldTravel = true;
    }
    
    private void Update() 
    {
        if(!_shouldTravel) return;
        Travel();
    }

    private void OnDisable() 
    {
        _shouldTravel = false;
    }

    private void Travel()
    {
        transform.Translate(travelDir * Time.deltaTime * _travelSpeed);
    }

    public EBulletType GetBulletType()
    {
        return bulletType;
    }
}
