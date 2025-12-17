using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private GameManager _gameManager;
    [SerializeField] private int maxEnemies;
    
    private float _lastSpawnTime;
    private int _currentEnemies;

    private void Start()
    {
        Spawn();
        
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        //spawn enemy each second
        if (Time.time - _lastSpawnTime > 1f && _currentEnemies < maxEnemies)
        {
            Spawn();
        }
    }

    public void EnemyDied()
    {
        _currentEnemies--;
        _gameManager.IncreaseScore(1);
    }
    
    private void Spawn()
    {
        //set the time of the enemy spawn
        _lastSpawnTime = Time.time;
        //spawn enemy under spawner
        var createdEnemy = Instantiate(enemy, GetRandomLocation(), Quaternion.identity);
        createdEnemy.transform.parent = transform;

        _currentEnemies++;
    }

    private Vector3 GetRandomLocation()
    {
        return new Vector3(Random.Range(0.52f, 99.38f), 2, Random.Range(-20.76f, 78.08f));
    }
}
