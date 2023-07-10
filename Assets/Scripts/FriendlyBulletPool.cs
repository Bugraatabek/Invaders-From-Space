using System;
using UnityEngine;
using UnityEngine.Pool;

public class FriendlyBulletPool : MonoBehaviour 
{
    public FriendlyBullet friendlyBullet;
    
    private IObjectPool<FriendlyBullet> _bulletPool;
    private Transform _startingPoint;
    
    private void Awake() 
    {
        _startingPoint = FindObjectOfType<PlayerController>().transform;
        _bulletPool = new ObjectPool<FriendlyBullet>(CreateBullet, OnGet, OnRelease, maxSize: 5);
    }

    private void OnRelease(FriendlyBullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnGet(FriendlyBullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = _startingPoint.position;
    }

    private FriendlyBullet CreateBullet()
    {
        return Instantiate(friendlyBullet, _startingPoint.position, Quaternion.identity);
    }

    public void GetBullet()
    {
        _bulletPool.Get();
    }

    public void ReleaseBullet(FriendlyBullet friendlyBullet)
    {
        _bulletPool.Release(friendlyBullet);
    }
}