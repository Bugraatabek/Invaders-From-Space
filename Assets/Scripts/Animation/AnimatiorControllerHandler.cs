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
        if(gameObject.transform.tag != "Player") return;
        InputReader.instance.shoot += Shoot;
    }

    public void Shoot()
    {
        animator.SetTrigger("Shoot");
    }

    public void Death()
    {
        animator.SetTrigger("Death");
    }

    private void OnDisable()
    {
        if(gameObject.transform.tag != "Player") return;
        InputReader.instance.shoot -= Shoot;
    }
}
