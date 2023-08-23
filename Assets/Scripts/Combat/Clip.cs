using System;
using System.Collections.Generic;
using UnityEngine;

public class Clip : MonoBehaviour 
{
    [SerializeField] private int _clipSize;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private EBulletType bulletType;
    public event Action<int> observeBullets;

    private int _currentBulletCount;

    private void Awake() 
    {
        _currentBulletCount = _clipSize;
    }

    private void Start() 
    {
        observeBullets?.Invoke(_currentBulletCount);
    }

    public void GetBullet(int damage)
    {
        if(_currentBulletCount <= 0)
        {
            print($"{this.name} is Out Of Bullets");
            return;
        }
        _currentBulletCount -= 1;
        observeBullets?.Invoke(_currentBulletCount);
        _bulletPool.GetPooledBullet(transform.position, damage);
    }

    public void AddBullets(int bulletAmount)
    {
        _currentBulletCount += bulletAmount;
        observeBullets?.Invoke(_currentBulletCount);
    }

    public void SetBulletPool(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public EBulletType GetBulletType()
    {
        return bulletType;
    }

    public int GetCurrentAmmoCount()
    {
        return _currentBulletCount;
    }
}
