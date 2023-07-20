using System.Collections.Generic;
using UnityEngine;

public class Clip : MonoBehaviour 
{
    [SerializeField] private int _clipSize;
    [SerializeField] private ObjectPool _objectPool;

    private int _currentBulletCount;

    private void Awake() 
    {
        _currentBulletCount = _clipSize;
    }
    
    public void GetBullet()
    {
        if(_currentBulletCount <= 0)
        {
            print($"{this.name} is Out Of Bullets");
            return;
        }
        _currentBulletCount -= 1;
        _objectPool.GetPooledObject(transform.position);
    }
}
