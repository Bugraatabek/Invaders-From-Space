using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour 
{
    // private Queue<Bullet> pooledBullets;
    // [SerializeField] private GameObject objectPrefab;
    // [SerializeField] private int poolSize;

    // private void Awake() 
    // {
    //     pooledBullets = new Queue<Bullet>();
    //     for (int i = 0; i < poolSize; i++)
    //     {
    //         GameObject obj = Instantiate(objectPrefab, transform.parent);
    //         obj.SetActive(false);
    //         pooledBullets.Enqueue(Bullet);
    //     }
    // }

    // public GameObject GetPooledObject()
    // {
    //     Bullet bulletToGet = pooledBullets.Dequeue();
    //     bulletToGet.gameObject.SetActive(true);
    //     pooledBullets.Enqueue(bulletToGet);
    //     return bulletToGet;
    // }

    // public GameObject GetPooledObject(Vector3 spawnLocation)
    // {
    //     GameObject objectToGet = pooledBullets.Dequeue();
    //     objectToGet.transform.position = spawnLocation;
    //     objectToGet.SetActive(true);
    //     pooledBullets.Enqueue(objectToGet);
    //     return objectToGet;
    // }

    // public void ReleasePooledObject(GameObject obj)
    // {
    //     obj.SetActive(false);
    // }    
}