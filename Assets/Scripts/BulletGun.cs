using UnityEngine;

public class BulletGun : Gun 
{
    //public FriendlyBulletPool friendlyBulletPoolPrefab;
    private bool _shouldShoot {get {return base.shouldShoot; }}
    //private FriendlyBulletPool friendlyBulletPoolInstance;
    [SerializeField] private ObjectPool objectPool;

    private void Awake() 
    {
        //friendlyBulletPoolInstance = Instantiate(friendlyBulletPoolPrefab, transform.parent);
    }

    public override void Shoot()
    {
        if(!_shouldShoot) return;
        base.Shoot();
        //friendlyBulletPoolInstance.GetBullet(); 
        objectPool.GetPooledObject();
    }
}