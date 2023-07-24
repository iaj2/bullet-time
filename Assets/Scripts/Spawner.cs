using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject enemyActive;
    public int spawnAmount;

    
    // Start is called before the first frame update
    void Start()
    {
        waveOne();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void waveOne()
    {
        spawnAmount = 3;
        
        while (spawnAmount > 0)
        {
            Instantiate(enemyPrefab, transform.position, transform.localRotation);
            spawnAmount--;
        }
        

    }
    void checkEnemyActivity()
    {
        enemyActive = GameObject.FindGameObjectWithTag("Enemy");

    }
}
