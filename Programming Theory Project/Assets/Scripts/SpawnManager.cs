using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public ParticleSystem thrustFlame;

    public bool counted = false;

    private GameManager gameManager;

    private float zEnemySpawn = 60.0f;
    private float xSpawnRange = 40.0f;
    private float ySpawn = 0.75f;

    private float enemySpawnTime = 2.0f;

    private GameObject spawned;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        if (enemySpawnTime > 0.1f)
        {
            if (gameManager.isGameActive)
                enemySpawnTime -= Time.deltaTime / 25;
        }
    }

    IEnumerator SpawnEnemy()
    {
        
        yield return new WaitForSeconds(enemySpawnTime);
        
        if (gameManager.isGameActive)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, enemies.Length);

            Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

            spawned = Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].transform.rotation);
            Instantiate(thrustFlame, spawned.transform.position, thrustFlame.transform.rotation, spawned.transform);
        }
        StartCoroutine(SpawnEnemy());
    }

}