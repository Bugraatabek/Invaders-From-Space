using UnityEngine;

public class FriendlyBullet : Bullet, IGetEffectedOnCollision
{
    public void CollisionEffect()
    {
       gameObject.SetActive(false);
    }

    public override void Travel()
    {
        transform.Translate(Vector2.up * Time.deltaTime * base.TravelSpeed);
    }
}