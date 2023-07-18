using UnityEngine;

public class Spawner : MonoBehaviour 
{   
    private static Spawner Instance = null;
    
    private void Awake() 
    {
        if(Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    
    public static void Spawn(GameObject objectToSpawn, Vector3 spawnPosition)
    {
        GameObject objectInstance = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}