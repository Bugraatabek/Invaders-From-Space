using UnityEngine;

public class Equipment : MonoBehaviour 
{
    [SerializeField] private Gun _gun;
    
    

    public Gun GetGun()
    {
        return _gun;
    }
}