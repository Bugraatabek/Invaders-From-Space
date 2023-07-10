using UnityEngine;

public class ReleaseAtABoundry : MonoBehaviour 
{
    // FriendlyBulletPool _friendlyBulletPool;
    // FriendlyBullet friendlyBullet;
    
    private void Start() 
    {
        // _friendlyBulletPool = FindObjectOfType<FriendlyBulletPool>();
        // friendlyBullet = GetComponent<FriendlyBullet>();
    }

    private void Update() 
    {
        if(gameObject.transform.position.y >= LevelBoundry.height)
        {
            gameObject.SetActive(false);
            // _friendlyBulletPool.ReleaseBullet(friendlyBullet);
        }
    }
}