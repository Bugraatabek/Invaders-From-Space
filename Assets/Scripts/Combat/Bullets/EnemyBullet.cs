using UnityEngine;

public class EnemyBullet : Bullet
{
    private void Awake() 
    {
        base.travelDir = Vector2.down;    
    }
}