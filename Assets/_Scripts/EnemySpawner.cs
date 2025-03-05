using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Stats")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float WaveDownTime = 5.0f;
    [SerializeField] private float DifficultyScaling = 0.75f;

    [Header("Events")]
    public static UnityEvent onEnemyDeath = new UnityEvent();

    private int currentWave = 1;
    private float TimeSinceLastSpawn;
    private int AliveEnemies;
    private int RemainingToSpawnEnemies;
    private bool isSpawning = false;

    private void Awake()
    {
        onEnemyDeath.AddListener(EnemyDeath);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }
    private void Update()
    {
        if (!isSpawning) return;

        TimeSinceLastSpawn += Time.deltaTime;

        if (TimeSinceLastSpawn >= (1.0f/ enemiesPerSecond) && RemainingToSpawnEnemies > 0)
        {
            
            SpawnEnemy();
            RemainingToSpawnEnemies--;
            AliveEnemies++;
            TimeSinceLastSpawn = 0.0f;
        }

        if (AliveEnemies == 0 && RemainingToSpawnEnemies == 0)
        {
            EndWave();
        }
    }
    private void EnemyDeath()
    {
        AliveEnemies--;
    }
    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(WaveDownTime);

        isSpawning = true;
        RemainingToSpawnEnemies = EnemiespPerWave();
    }

    private void EndWave()
    {
        isSpawning = false;
        TimeSinceLastSpawn = 0.0f;
        currentWave++;
        StartCoroutine(StartWave());
    }
    private void SpawnEnemy()
    {
        //Debug.Log("Enemy Spawned!");
        GameObject prefabToSpawn = enemyPrefabs[0];
        Instantiate(prefabToSpawn, GameManager.main.StartPoint.position, Quaternion.identity);
    }
    private int EnemiespPerWave() 
    { 
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, DifficultyScaling));
    }



}
