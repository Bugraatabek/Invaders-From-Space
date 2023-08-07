using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPool : MonoBehaviour
{
    private Queue<Pickup> pooledPickups;
    [SerializeField] private Pickup pickupPrefab;
    [SerializeField] private int poolSize;
    [SerializeField] private int poolLevel;

    private void Awake() 
    {
        pooledPickups = new Queue<Pickup>();
        for (int i = 0; i < poolSize; i++)
        {
            Pickup pickup = Instantiate(pickupPrefab, transform);
            pickup.gameObject.SetActive(false);
            pooledPickups.Enqueue(pickup);
        }
    }

    public Pickup GetPooledPickup()
    {
        Pickup pickupToGet = pooledPickups.Dequeue();
        pickupToGet.gameObject.SetActive(true);
        pooledPickups.Enqueue(pickupToGet);
        return pickupToGet;
    }

    public Pickup GetPooledPickup(Vector3 spawnLocation)
    {
        print("Getting Bullet From Pool");
        Pickup pickupToGet = pooledPickups.Dequeue();
        pickupToGet.transform.position = spawnLocation;
        pickupToGet.gameObject.SetActive(true);
        pooledPickups.Enqueue(pickupToGet);
        return pickupToGet;
    }

    public void ReleasePooledPickup(Pickup pickup)
    {
        pickup.gameObject.SetActive(false);
    }

    public int GetPoolLevel()
    {
        return poolLevel;
    }  
}

