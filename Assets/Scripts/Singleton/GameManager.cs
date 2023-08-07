using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] allAlienSets;
    private GameObject currentSet;
    [SerializeField] private Vector2 spawnPos;
    private int currentWave = 0;

    public event Action<int> observeWave;
    [SerializeField] private Dictionary<EBulletType, BulletPool> bulletPoolsDict;
    
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
        BuildBulletPoolDict();
    }

    private void Start() 
    {
        SpawnNewWave();
    }

    public void SpawnNewWave()
    {
        if(currentWave >= allAlienSets.Length)
        {
            currentWave = 0;
        }
        StartCoroutine(SpawnWave(currentWave));
        currentWave++;
        observeWave?.Invoke(currentWave);
        
    }

    private IEnumerator SpawnWave(int waveToInstantiate)
    {
        if(currentSet != null)
        {
            AlienList.Instance.waveFinished -= SpawnNewWave;
            Destroy(currentSet);
        }
        yield return new WaitForSeconds(3);
        currentSet = Instantiate(allAlienSets[waveToInstantiate], spawnPos, Quaternion.identity);
        AlienList.Instance.waveFinished += SpawnNewWave;
    }

    private void BuildBulletPoolDict()
    {
        bulletPoolsDict = new Dictionary<EBulletType, BulletPool>();
        foreach (var bulletPool in FindObjectsOfType<BulletPool>())
        {
            bulletPoolsDict.Add(bulletPool.GetBulletType(), bulletPool);
        }
    }

    public BulletPool GetBulletPool(EBulletType bulletType)
    {
        return bulletPoolsDict[bulletType];
    }
}
