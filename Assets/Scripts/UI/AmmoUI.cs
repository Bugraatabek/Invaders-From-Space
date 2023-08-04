using System;
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI bulletText;

    [SerializeField] Shooter shooter;

    private Clip clipToObserve;

    private void OnEnable() 
    {
        shooter.observeGun += ChangeCurrentClip;
    }

    private void ChangeCurrentClip(Gun gun)
    {
        if(clipToObserve != null)
        {
            clipToObserve.observeBullets -= UpdateUI;
        }
        clipToObserve = gun.GetComponent<Clip>();
        clipToObserve.observeBullets += UpdateUI; 
    }

    private void UpdateUI(int currentBullets)
    {
        bulletText.text = currentBullets.ToString();
    }

    private void OnDisable() 
    {
        shooter.observeGun -= ChangeCurrentClip;
        if(clipToObserve != null)
        {
            clipToObserve.observeBullets -= UpdateUI;
        }
    }
}