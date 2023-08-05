using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupAnimationSpawner : MonoBehaviour
{
    public static PickupAnimationSpawner instance;
    [SerializeField] GameObject animationPrefab;
    
    private void Awake() 
    {
        if(instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void SpawnPickupAnimation(string pickupText)
    {
        var animationInstance = Instantiate(animationPrefab, transform);
        TextMeshProUGUI animationText = animationInstance.GetComponentInChildren<TextMeshProUGUI>();
        animationText.text = pickupText;
    }
}
