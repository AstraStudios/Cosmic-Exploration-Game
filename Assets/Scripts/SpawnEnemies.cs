using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemyObj;
    [SerializeField] float waitTime;

    bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning)
            StartCoroutine(WaitToSpawn());
    }

    IEnumerator WaitToSpawn()
    {
        isSpawning = true;
        yield return new WaitForSeconds(waitTime);
        Instantiate(enemyObj, new Vector2(Random.Range(-6, 5.8f), Random.Range(-10, 10)), Quaternion.identity);

        isSpawning = false;
    }
}
