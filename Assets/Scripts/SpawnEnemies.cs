using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemies;

    private float spawnPosXMin = 3;
    private float spawnPosXMax= 13;
    private float spawnPosY = 5;
    public bool CanSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
            InvokeRepeating("SpawnEnemy",2f,5f);
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(spawnPosXMin, spawnPosXMax);
        float yPos = Random.Range(-spawnPosY, spawnPosY);
        return new Vector2(xPos, yPos);
    }

    void SpawnEnemy()
    {
        int indexEnemies = Random.Range(0,1);
            
        Instantiate(enemies[indexEnemies], GenerateSpawnPosition(), enemies[indexEnemies].transform.rotation);
            
       
        
    }
}
