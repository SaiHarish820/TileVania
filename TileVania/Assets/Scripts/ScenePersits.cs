using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersits : MonoBehaviour
{
    private void Awake()
    {
        int numScenePersisits = FindObjectsOfType<GameSession>().Length;

        if(numScenePersisits > 1)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject); 
        
        }
    }

    public void ResetScenePersits()
    {
        Destroy(gameObject);
    }
}
