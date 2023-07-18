using System.Collections.Generic;
using UnityEngine;

public class AlienList : MonoBehaviour 
{
    private static AlienList Instance = null;

    public static List<GameObject> allAliens = new List<GameObject>();

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

    private void Start() 
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            allAliens.Add(transform.GetChild(i).gameObject);
        }
    }

    public static void RemoveFromList(GameObject obj)
    {
        allAliens.Remove(obj);
    }

    public static void AddToList(GameObject obj)
    {
        allAliens.Add(obj);
    }

    public static int GetListCount()
    {
        return allAliens.Count;
    }

    public static GameObject GetListedGameObject(int i)
    {
        return allAliens[i];
    }
}