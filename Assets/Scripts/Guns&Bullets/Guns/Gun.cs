using UnityEngine;

[RequireComponent(typeof(Clip))]
public class Gun : MonoBehaviour
{
    private Clip clip;

    [SerializeField] private float cooldown;
    
    
    protected bool ShouldShoot {get { return _shouldShoot; }}
    
    private bool _shouldShoot = true;
    private float cooldownCounter = Mathf.Infinity;

    private void Awake() 
    {
        clip = GetComponent<Clip>();
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
        if(cooldownCounter < cooldown) return;
        clip.GetBullet();
        cooldownCounter = 0;
    }
}