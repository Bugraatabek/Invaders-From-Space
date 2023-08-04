using UnityEngine;

public class Engine : MonoBehaviour 
{
    [SerializeField] private float _moveSpeed;
    Mover mover;
    private void Awake() 
    {
        mover = GetComponentInParent<Mover>();
    }

    private void OnEnable() 
    {
        mover.SetSpeed(_moveSpeed);
    }
}