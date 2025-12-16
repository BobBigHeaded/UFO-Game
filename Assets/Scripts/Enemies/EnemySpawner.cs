using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] private int maxEnemies;
    
    private float _lastSpawnTime;
    private int _currentEnemies;

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if (Time.time - _lastSpawnTime > 1f && _currentEnemies < maxEnemies)
        {
            Spawn();
        }
    }

    public void EnemyDied()
    {
        _currentEnemies--;
    }
    
    private void Spawn()
    {
        _lastSpawnTime = Time.time;
        Instantiate(enemy, GetRandomLocation(), Quaternion.identity);

        _currentEnemies++;
    }

    private Vector3 GetRandomLocation()
    {
        return new Vector3(Random.Range(0.52f, 99.38f), 2, Random.Range(-20.76f, 78.08f));
    }
}
