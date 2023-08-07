using UnityEngine;

public class ShieldManager : MonoBehaviour 
{
    [SerializeField] private Shield[] shields;

    public void ActivateRandomShield()
    {
        foreach (var shieldToCheck in shields)
        {
            if(shieldToCheck.gameObject.activeInHierarchy)
            {
                shieldToCheck.ResetShield();
                return;
            }
        }
        int randomNumber = Random.Range(0,shields.Length);
        Shield shield = shields[randomNumber];
        shield.gameObject.SetActive(true);
        shield.ResetShield();
    }

    public void ActivateShield(EShieldType shieldType)
    {
        foreach (Shield shield in shields)
        {
            shield.gameObject.SetActive(false);
            if(shield.GetShieldType() == shieldType)
            {
                shield.gameObject.SetActive(true);
                shield.ResetShield();
            }
            
        }
    }
}