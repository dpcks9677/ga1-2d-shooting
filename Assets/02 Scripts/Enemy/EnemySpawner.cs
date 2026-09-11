using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawnDataTableSO _spawnDataTable;

    [SerializeField] private float _spawnInterval = 3f;

    private void Start()
    {
    }

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
        // 1. 전체 가중치 합산
        int totalWeight = 0;

        foreach (EnemySpawnData data in _spawnDataTable.Datas)
        {
            totalWeight += data.Weight;
        }

        // 2. 전체 가중치 범위에서 랜덤한 점수를 추첨
        int randomWeight = Random.Range(0, totalWeight);

        int cumulativeWeight = 0;
        foreach (EnemySpawnData data in _spawnDataTable.Datas)
        {
            cumulativeWeight += data.Weight;
            if (randomWeight < cumulativeWeight)
            {
                GameObject enemy = Instantiate(data.EnemyPrefab);
                enemy.transform.position = transform.position;
                break;
            }
        }
    }
}