using TMPro;
using UnityEngine;

public class DamageUI : MonoBehaviour 
{
    [SerializeField] Shooter playerShooter;
    [SerializeField] TextMeshProUGUI damageText;

    
    private void Start() 
    {
        playerShooter.observeGun += UpdateUI;
    }
    
    private void UpdateUI(Gun gun)
    {
        damageText.text = $"Damage: {gun.GetDamage()}";    
    }

    private void OnDisable()
    {
        playerShooter.observeGun -= UpdateUI;
    }

    
}