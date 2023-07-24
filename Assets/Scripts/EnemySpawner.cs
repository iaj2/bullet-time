using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPreFab;

    public float enemyInterval = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyInterval, enemyPreFab));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSecondsRealtime(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5.3f, -5), Random.Range(-0.22f, -2.16f), 0), Quaternion.identity);
        yield return new WaitForSecondsRealtime(interval);
        GameObject newEnemy2 = Instantiate(enemy, new Vector3(Random.Range(3.33f, 5.6f), Random.Range(7.11f, 7f), 0), Quaternion.identity);
        yield return new WaitForSecondsRealtime(interval);
        GameObject newEnemy3 = Instantiate(enemy, new Vector3(Random.Range(-11.79f, -11.50f), Random.Range(8.68f, 10.38f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
