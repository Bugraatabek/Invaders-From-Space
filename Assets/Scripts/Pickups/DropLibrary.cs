using UnityEngine;

[CreateAssetMenu(fileName = "DropLibrary", menuName = "DropLibrary", order = 0)]
public class DropLibrary : ScriptableObject 
{
    [SerializeField] Pickup[] pickupLibrary;
    
    public Pickup[] GetPickups()
    {
        return pickupLibrary;
    }
}