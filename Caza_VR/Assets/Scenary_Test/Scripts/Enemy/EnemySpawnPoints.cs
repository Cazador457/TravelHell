using UnityEngine;
using System.Collections.Generic;

public class EnemySpawnPoints : MonoBehaviour
{
    [Header("Configuración de Enemigos")]
    public string enemyTag;
    public float spawnInterval = 6f;
    public int maxEnemies = 8;

    [Header("Puntos de Spawn")]
    public List<Transform> spawnPoints = new List<Transform>();

    [Header("Detección de espacio libre")]
    public float spawnCheckRadius = 1.5f;
    public LayerMask enemyLayer;

    [Header("Rutas (opcional)")]
    public Transform[] route1;
    public Transform[] route2;

    private int currentEnemies;
    private float nextSpawn;

    void Start()
    {
        nextSpawn = Time.time + spawnInterval;
    }

    void Update()
    {

        if (Time.time >= nextSpawn && currentEnemies < maxEnemies)
        {
            TrySpawn();
            nextSpawn = Time.time + spawnInterval;
        }
    }

    void TrySpawn()
    {
        if (spawnPoints.Count == 0)
        {
            Debug.LogWarning("No hay puntos de spawn asignados en el inspector.");
            return;
        }

        List<Transform> validPoints = new List<Transform>();

        foreach (Transform point in spawnPoints)
        {
            if (point == null) continue;

            Collider[] hits = Physics.OverlapSphere(point.position, spawnCheckRadius, enemyLayer);
            if (hits.Length == 0)
                validPoints.Add(point);
        }

        if (validPoints.Count == 0)
        {
            return;
        }

        Transform spawnPoint = validPoints[Random.Range(0, validPoints.Count)];

        Transform[] selectedRoute = Random.value > 0.5f ? route1 : route2;

        GameObject newEnemy = PoolManager.Instance.SpawnFromPool(
            enemyTag,
            spawnPoint.position,
            spawnPoint.rotation,
            selectedRoute
        );

        if (newEnemy != null)
        {
            currentEnemies++;

            Enemy enemyComponent = newEnemy.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.onDeath += OnEnemyDeath;
            }
        }
    }

    void OnEnemyDeath()
    {
        currentEnemies--;
        GameManager.Instance.enemiesKilled++;
    }
}