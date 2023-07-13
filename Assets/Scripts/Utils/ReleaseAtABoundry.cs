using UnityEngine;

public class ReleaseAtABoundry : MonoBehaviour 
{
    private void Update() 
    {
        if(gameObject.transform.position.y >= LevelBoundry.height)
        {
            gameObject.SetActive(false);
        }
    }
}