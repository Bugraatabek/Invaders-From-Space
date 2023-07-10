using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour 
{
    private Queue<GameObject> pooledObjects;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize;
    [SerializeField] private Transform startingPoint;

    private void Awake() {
        pooledObjects = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            pooledObjects.Enqueue(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        GameObject obj = pooledObjects.Dequeue();
        obj.transform.position = startingPoint.position;
        obj.SetActive(true);
        pooledObjects.Enqueue(obj);
        return obj;
    }

    public void ReleasePooledObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}