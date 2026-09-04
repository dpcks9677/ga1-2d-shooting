using UnityEngine;

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
        int randomIndex = Random.Range(0, _enemyPrefabs.Length);
        Enemy enemy = Instantiate(_enemyPrefabs[randomIndex]);

        enemy.transform.position = transform.position;
    }
}