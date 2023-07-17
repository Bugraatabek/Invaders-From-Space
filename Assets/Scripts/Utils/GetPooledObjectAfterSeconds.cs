using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPooledObjectAfterSeconds : MonoBehaviour
{
    protected float _timer;

    [SerializeField] private float initalTime;

    [SerializeField] private ObjectPool objectPool = null;

    private void Awake() 
    {
        _timer = initalTime;    
    }

    private void Update() 
    {
        if(_timer <= 0)
        {
            GetPooledObject();
        }
        _timer -= Time.deltaTime;
    }

    public virtual void GetPooledObject()
    {
        objectPool.GetPooledObject();
        _timer = initalTime;
    }
}
