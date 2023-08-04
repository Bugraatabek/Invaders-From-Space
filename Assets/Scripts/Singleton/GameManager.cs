using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] allAlienSets;
    private GameObject currentSet;
    private Vector2 spawnPos = new Vector2(0,0);
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
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        if(currentSet != null)
        {
            Destroy(currentSet);
        }
        yield return new WaitForSeconds(3);
        currentSet = Instantiate(allAlienSets[Random.Range(0,allAlienSets.Length)], spawnPos, Quaternion.identity);
        PlayerUI.Instance.UpdateWave();
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
