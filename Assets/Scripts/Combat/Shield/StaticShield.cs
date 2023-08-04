using UnityEngine;

public class StaticShield : Shield 
{
    [SerializeField] private Sprite[] states;
    private SpriteRenderer spriteRenderer;
    
    protected override void Awake() 
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void UpdateShield()
    {
        base.UpdateShield();
        if(base.isDead) return;
        spriteRenderer.sprite = states[(int)base.health.GetCurrentHealth() - 1];
    }
}