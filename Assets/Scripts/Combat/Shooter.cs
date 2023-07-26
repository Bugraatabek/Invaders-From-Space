using UnityEngine;

public class Shooter : MonoBehaviour 
{
    private Gun _gun;

    private void Awake() 
    {
        _gun = GetComponent<Gun>();
    }

    private void OnEnable() 
    {
        InputReader.shoot += Shoot;
    }

    private void OnDisable() 
    {
        InputReader.shoot -= Shoot;
    }

    public void Shoot()
    {
        if(!_gun) 
        {
            print("Gun is not equiped");
            return;
        }
        _gun.Shoot();
    }
}