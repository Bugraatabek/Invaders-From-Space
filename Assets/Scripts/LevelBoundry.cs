using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundry : MonoBehaviour
{
    Camera cam;
    public static float width {get {return _width; } }
    public static float height {get {return _height; } }
    public static float widthForPlayer {get {return _widthForPlayer; } }
    
    private static float _width;
    private static float _widthForPlayer; 
    private static float _height;
    
    private void Awake()
    {
        cam = Camera.main;
        _width =  ((1/(cam.WorldToViewportPoint(new Vector3(1,1,0)).x -0.5f)/2));
        _height =  ((1/(cam.WorldToViewportPoint(new Vector3(1,1,0)).y -0.5f)/2));
        _widthForPlayer = _width - 0.25f; 
        print(_width);
    }
}
