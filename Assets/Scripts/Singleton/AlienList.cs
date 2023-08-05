using System;
using System.Collections.Generic;
using UnityEngine;

public class AlienList : MonoBehaviour 
{
    public static AlienList Instance = null;

    [SerializeField] public List<Alien> allAliens = new List<Alien>();

    public event Action waveFinished;

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

        foreach (Alien alien in GetComponentsInChildren<Alien>())
        {
            allAliens.Add(alien);
        }
    }

    public void RemoveFromList(Alien alien)
    {
        allAliens.Remove(alien);
        if(allAliens.Count <= 0)
        {
            waveFinished?.Invoke();
        }
    }

    public void AddToList(Alien alien)
    {
        allAliens.Add(alien);
    }

    public int GetListCount()
    {
        return allAliens.Count;
    }

    public Alien GetListedGameObject(int i)
    {
        return allAliens[i];
    }
}