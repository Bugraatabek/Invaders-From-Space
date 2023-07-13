using UnityEngine;

public class Gun : MonoBehaviour 
{
    public PlayerController player;
    public float cooldown;
    
    protected bool ShouldShoot {get { return _shouldShoot; }}
    
    private bool _shouldShoot = true;
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
            _shouldShoot = false;
        }
        else
        {
            _shouldShoot = true;
        }
    }

    public virtual void Shoot()
    {
        cooldownCounter = 0;
        //add subclass logic.
    }
}