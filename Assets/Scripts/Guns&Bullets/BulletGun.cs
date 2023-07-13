using UnityEngine;

public class BulletGun : Gun 
{
    private bool _shouldShoot {get {return base.ShouldShoot; }}
    [SerializeField] private ObjectPool objectPool;

    public override void Shoot()
    {
        if(!_shouldShoot) return;
        base.Shoot();
        objectPool.GetPooledObject();
    }
}