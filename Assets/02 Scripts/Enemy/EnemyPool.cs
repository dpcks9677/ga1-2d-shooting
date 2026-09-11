using System;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [Header("Enemy 프리팹들")] [SerializeField]
    private Enemy[] _enemyPrefabs;

    [Header("풀 사이즈")] [SerializeField] private int _poolSize;

    private Enemy[,] _pool;

    private static EnemyPool _instance = null;
    public static EnemyPool Instance = _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        _pool = new Enemy[_enemyPrefabs.Length, _poolSize];

        for (int i = 0; i < _enemyPrefabs.Length; i++)
        {
            Enemy enemyPrefab = _enemyPrefabs[i];
            for (int j = 0; j < _poolSize; j++)
            {
                Enemy enemy = Instantiate(enemyPrefab, gameObject.transform);
                enemy.gameObject.SetActive(false);
                _pool[i, j] = enemy;
            }
        }
    }

    public Enemy GetEnemy(EnemyType enemyType)
    {
        for (int i = 0; i < _enemyPrefabs.Length; i++) // 타입별로 순회 하면서
        {
            if (_pool[i, 0].Type != enemyType) // 첫번째 요소의 타입이 내가 원하는게 아니라면 스킵
            {
                continue;
            }

            for (int j = 0; j < _poolSize; j++) // 원하는 타입의 배열 순회
            {
                Enemy enemy = _pool[i, j];

                // 비활성화 되어있는 (즉, 누가 빌려가지 않은 ) 총알 반환
                if (enemy.gameObject.activeSelf == false)
                {
                    enemy.gameObject.SetActive(true);
                    return enemy;
                }
            }
        }

        return null;
    }
}