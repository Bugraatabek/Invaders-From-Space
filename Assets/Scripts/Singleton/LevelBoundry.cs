using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundry : MonoBehaviour
{
    private static LevelBoundry Instance = null;

    Camera cam;
    public static float width {get {return _width; } }
    public static float height {get {return _height; } }
    
    private static float _width;
    private static float _height;
    
    
    private void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        CalculateBoundries();
    }

    private void CalculateBoundries()
    {
        cam = Camera.main;
        _width =  ((1/(cam.WorldToViewportPoint(new Vector3(1,1,0)).x -0.5f)/2));
        _height =  ((1/(cam.WorldToViewportPoint(new Vector3(1,1,0)).y -0.5f)/2));
    }
}
