using UnityEngine;

public enum EnemyType
{
    Normal,
    Lookup,
    Guide
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 3f;
    [SerializeField] private Enemy[] _enemyPrefabs;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            _timer = 0f;
            _spawnInterval = Random.Range(1f, 3f);
            Spawn();
        }
    }

    private void Spawn()
    {
        float randomIndex = Random.value;
        Enemy enemy = null;

        if (randomIndex <= 0.5f)
        {
            enemy = Instantiate(_enemyPrefabs[(int)EnemyType.Normal]);
        }
        else if (randomIndex <= 0.70f)
        {
            enemy = Instantiate(_enemyPrefabs[(int)EnemyType.Lookup]);
        }
        else
        {
            enemy = Instantiate(_enemyPrefabs[(int)EnemyType.Guide]);
        }

        enemy.transform.position = transform.position;
    }
}