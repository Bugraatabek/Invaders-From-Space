using UnityEngine;

public class EnemyBullet : Bullet, IGetEffectedOnCollision
{
    public void CollisionEffect()
    {
        gameObject.SetActive(false);
    }

    public override void Travel()
    {
        transform.Translate(Vector2.down * Time.deltaTime * base.TravelSpeed);
    }
}