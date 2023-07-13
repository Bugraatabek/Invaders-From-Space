using UnityEngine;

public class DestroyOnAnimationEnd : MonoBehaviour 
{
    public float delayAfterAnimation;

    private void Start() 
    {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delayAfterAnimation);
    }
}