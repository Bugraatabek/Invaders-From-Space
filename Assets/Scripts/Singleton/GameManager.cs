using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] allAlienSets;
    private GameObject currentSet;
    [SerializeField] private BulletPool alienBulletPool;
    private Vector2 spawnPos = new Vector2(0,0);
    
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
        foreach (var clip in currentSet.GetComponentsInChildren<Clip>())
        {
            clip.SetBulletPool(alienBulletPool);
        }

        PlayerUI.Instance.UpdateWave();
    }
}
