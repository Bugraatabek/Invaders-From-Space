using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour 
{
    private Queue<Bullet> pooledBullets;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int poolSize;

    private void Awake() 
    {
        pooledBullets = new Queue<Bullet>();
        for (int i = 0; i < poolSize; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform);
            bullet.gameObject.SetActive(false);
            pooledBullets.Enqueue(bullet);
        }
    }

    public Bullet GetPooledBullet()
    {
        Bullet bulletToGet = pooledBullets.Dequeue();
        bulletToGet.gameObject.SetActive(true);
        pooledBullets.Enqueue(bulletToGet);
        return bulletToGet;
    }

    public Bullet GetPooledBullet(Vector3 spawnLocation, int damage)
    {
        Bullet bulletToGet = pooledBullets.Dequeue();
        bulletToGet.SetDamage(damage);
        bulletToGet.transform.position = spawnLocation;
        bulletToGet.gameObject.SetActive(true);
        pooledBullets.Enqueue(bulletToGet);
        return bulletToGet;
    }

    public void ReleasePooledBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }    
}