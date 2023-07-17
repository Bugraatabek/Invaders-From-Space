using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMover : MonoBehaviour
{
    private Vector3 _horizontalStepLength = new Vector3(0.05f,0,0);
    private Vector3 _verticalStepLength = new Vector3(0,0.15f,0);

    private float _totalTimeToMoveAliens = 0.01f;
    private float _moveSpeedMultiplier = 0.005f;

    private bool _movingRight;
    private const float MAX_MOVE_SPEED = 0.02f; 

    void FixedUpdate()
    {
        if(_totalTimeToMoveAliens <= 0)
        {
            MoveEnemies();
        }
        _totalTimeToMoveAliens -= Time.deltaTime;
    }

    private void MoveEnemies()
    {
        int hitMax = 0;
        for (int i = 0; i < AlienList.GetListCount(); i++)
        {
            if(_movingRight)
            {
                AlienList.GetListedGameObject(i).transform.position += _horizontalStepLength;
            }
            if(!_movingRight)
            {
                AlienList.GetListedGameObject(i).transform.position -= _horizontalStepLength;
            }

            if(AlienList.GetListedGameObject(i).transform.position.x > LevelBoundry.widthForAlienMaster || AlienList.GetListedGameObject(i).transform.position.x < -LevelBoundry.widthForAlienMaster)
            {
                hitMax++;
            }
        }
        if(hitMax > 0)
        {
            for (int i = 0; i < AlienList.GetListCount(); i++)
            {
                AlienList.GetListedGameObject(i).transform.position -= _verticalStepLength;
            }
            _movingRight = !_movingRight;
        }
        _totalTimeToMoveAliens = GetMoveSpeed();
    }
    
    private float GetMoveSpeed()
    {
        float moveSpeed = AlienList.GetListCount() * _moveSpeedMultiplier;
        if(moveSpeed < MAX_MOVE_SPEED)
        {
            return MAX_MOVE_SPEED;
        }
        return moveSpeed;
        
    }
}
