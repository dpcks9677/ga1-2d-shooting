using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawnDataTableSO _spawnDataTable;
    [SerializeField] private EnemyBalanceDataTableSO _balanceDataTable;

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
                // 1. EnemyPool 싱글톤에서 타입에 맞는 적을 꺼내옴
                Enemy enemy = EnemyPool.Instance.GetEnemy(data.EnemyType);

                // 2. 풀에 여유가 있어 정상적으로 가져온 경우 처리
                if (enemy != null)
                {
                    // 3. 위치를 스포너 위치로 먼저 설정
                    enemy.transform.position = transform.position;
                    // 4. 상태 초기화 (현재 점수에 따른 체력 배율 적용, 회전값, 방향 등)
                    float multiplier = GetHealthMultiplier();
                    enemy.OnSpawn(multiplier);
                }

                break;
            }
        }
    }

    public float GetHealthMultiplier()
    {
        // 현재 score에 따라 체력 배율 반환
        if (_balanceDataTable == null || _balanceDataTable.datas == null || _balanceDataTable.datas.Length == 0)
        {
            return 1f;
        }

        int currentScore = ScoreManager.Instance.Score;
        float multiplier = 1f;

        foreach (EnemyBalanceData data in _balanceDataTable.datas)
        {
            if (currentScore >= data.RequireScore)
            {
                multiplier = data.HealthMultiplier;
            }
            else
            {
                break;
            }
        }

        return multiplier;
    }
}