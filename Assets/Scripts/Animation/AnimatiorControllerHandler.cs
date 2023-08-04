using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatiorControllerHandler : MonoBehaviour
{
    Animator animator;

    
    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable() 
    {
        InputReader.instance.shoot += SetActive;
    }

    protected virtual void SetActive()
    {
        animator.SetTrigger("Shoot");
    }

    private void OnDisable()
    {
        InputReader.instance.shoot -= SetActive;
    }
}
