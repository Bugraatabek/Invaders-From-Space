using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected bool ShouldTravel{get {return _shouldTravel;}}
    protected float TravelSpeed {get {return _travelSpeed;}}
    private float _travelSpeed = 10f;
    private bool _shouldTravel;
    
    private void OnEnable() 
    {
        _shouldTravel = true;
    }
    
    private void Update() 
    {
        if(!_shouldTravel) return;
        Travel();
    }

    private void OnDisable() 
    {
        _shouldTravel = false;
    }

    public virtual void Travel()
    {
        // Traveling Logic
    }

   
}
