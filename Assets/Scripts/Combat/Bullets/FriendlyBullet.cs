using UnityEngine;

public class FriendlyBullet : Bullet
{
    private void Awake() 
    {
        base.travelDir = Vector2.up;
    }
}