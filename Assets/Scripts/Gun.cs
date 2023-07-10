using UnityEngine;

public class Gun : MonoBehaviour 
{
    public PlayerController player;
    public float cooldown;
    
    protected bool shouldShoot = true;
    
    private float cooldownCounter = Mathf.Infinity;
    
    private void Start() 
    {
        player.shoot += Shoot;
    }

    private void OnDisable() 
    {
        player.shoot -= Shoot;
    }

    private void Update() 
    {
        cooldownCounter += Time.deltaTime;
        if(cooldownCounter < cooldown)
        {
            shouldShoot = false;
        }
        else
        {
            shouldShoot = true;
        }
    }

    public virtual void Shoot()
    {
        cooldownCounter = 0;
    }
}