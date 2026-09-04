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


        //TODO : Scriptable Object를 사용해서 리팩토링 할 것
        //R1. 배열을 사용했지만 각 ㅏ이템에 어떤 프리팹인지 알 수가 없음
        //R2. 각 Enemy 스폰 확률을 매직넘버로 하드코딩해서 유지보수가 어려움
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