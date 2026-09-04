using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("스폰 간격")] [SerializeField] private float _spawnInterval = 3f;
    private float _timer;

    [Header("스폰할 프리팹")] [SerializeField] private Enemy _enemyPrefab;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            _timer = 0f;

            _spawnInterval = Random.Range(1f, 3f);
            int randomInt = Random.Range(1, 3);

            Spawn();
        }
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(_enemyPrefab);
        enemy.transform.position = transform.position;
    }
}