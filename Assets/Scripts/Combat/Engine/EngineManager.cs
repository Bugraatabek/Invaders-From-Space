using UnityEngine;

public class EngineManager : MonoBehaviour 
{
    [SerializeField] private Engine[] engines;
    private int engineLevel = 0;

    public void IncreaseEngineLevel()
    {
        if(engineLevel >= engines.Length) return;

        foreach (var engineToCheck in engines)
        {
            if(engineToCheck.gameObject.activeInHierarchy)
            {
                engineToCheck.gameObject.SetActive(false);
            }
        }
        
        Engine engine = engines[engineLevel];
        engine.gameObject.SetActive(true);
        
        engineLevel ++;
    }
}