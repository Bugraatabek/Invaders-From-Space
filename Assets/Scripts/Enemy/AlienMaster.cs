using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{
    public static List<GameObject> allAliens = new List<GameObject>();
    
    [SerializeField] private float shootTime = 3f;
    [SerializeField] private ObjectPool motherShipObjectPool;
    [SerializeField] private ObjectPool objectPool = null;

    private Vector3 hMoveDistance = new Vector3(0.05f,0,0);
    private Vector3 vMoveDistance = new Vector3(0,0.15f,0);

    private float MAX_LEFT = -2.5f;
    private float MAX_RIGHT = 2.5f;
    
    
    //Timers
    private float moveTimer = 0.01f;
    private float moveTime = 0.005f;
    private float _shootTimer = 3f;
    private float _motherShipTimer = 3f;

    private bool _movingRight;

    //Constants
    private const float MOTHERSHIP_MIN = 16f;
    private const float MOTHERSHIP_MAX = 60F;
    private const float MAX_MOVE_SPEED = 0.02f; 
    private const string ALIENTAG = "Alien";
    
    void Start()
    {
        _shootTimer = shootTime;
        foreach (GameObject alien in GameObject.FindGameObjectsWithTag(ALIENTAG))
        {
            allAliens.Add(alien);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(moveTimer <= 0)
        {
            MoveEnemies();
        }
        if(_shootTimer <= 0)
        {
            Shoot();
        }
        if(_motherShipTimer <= 0)
        {
            SpawnMotherShip();
        }
        _motherShipTimer -= Time.deltaTime;
        _shootTimer -= Time.deltaTime;
        moveTimer -= Time.deltaTime;
    }

    private void MoveEnemies()
    {
        int hitMax = 0;
        for (int i = 0; i < allAliens.Count; i++)
        {
            if(_movingRight)
            {
                allAliens[i].transform.position += hMoveDistance;
            }
            else
            {
                allAliens[i].transform.position -= hMoveDistance;
            }

            if(allAliens[i].transform.position.x > LevelBoundry.widthForAlienMaster || allAliens[i].transform.position.x < -LevelBoundry.widthForAlienMaster)
            {
                hitMax++;
            }
        }
        if(hitMax > 0)
        {
            for (int i = 0; i < allAliens.Count; i++)
            {
                allAliens[i].transform.position -= vMoveDistance;
            }
            _movingRight = !_movingRight;
        }
        moveTimer = GetMoveSpeed();
    }

    private void Shoot()
    {
        if(allAliens.Count <= 0) return;
        Vector2 pos = allAliens[UnityEngine.Random.Range(0, allAliens.Count)].transform.position;
        GameObject obj = objectPool.GetPooledObject();
        obj.transform.position = pos;
        _shootTimer = shootTime;
    }

    private void SpawnMotherShip()
    {
        GameObject motherShip = motherShipObjectPool.GetPooledObject();
        _motherShipTimer = UnityEngine.Random.Range(MOTHERSHIP_MIN,MOTHERSHIP_MAX);
        print(_motherShipTimer);
    }

    private float GetMoveSpeed()
    {
        float f = allAliens.Count * moveTime;
        if(f <MAX_MOVE_SPEED)
        {
            return MAX_MOVE_SPEED;
        }
        else
        {
            return f;
        }
    }
}


