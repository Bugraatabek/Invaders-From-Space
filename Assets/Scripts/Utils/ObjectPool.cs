using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour 
{
    private Queue<GameObject> pooledObjects;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize;

    private void Awake() 
    {
        pooledObjects = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab, transform.parent);
            obj.SetActive(false);
            pooledObjects.Enqueue(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        GameObject objectToGet = pooledObjects.Dequeue();
        objectToGet.SetActive(true);
        pooledObjects.Enqueue(objectToGet);
        return objectToGet;
    }

    public GameObject GetPooledObject(Vector3 spawnLocation)
    {
        GameObject objectToGet = pooledObjects.Dequeue();
        objectToGet.transform.position = spawnLocation;
        objectToGet.SetActive(true);
        pooledObjects.Enqueue(objectToGet);
        return objectToGet;
    }

    public void ReleasePooledObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}