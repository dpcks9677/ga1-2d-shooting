using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private EnemyType _type;
    public EnemyType Type => _type;

    //todo: enemy가 공격당할 때 재생되는 피격 사운드 출력
    [SerializeField] private AudioSource _damagedAudioSource;

    [SerializeField] private float _health = 100f;
    [SerializeField] protected float _moveSpeed;

    [SerializeField] private ItemSpawnDataTableSO _spawnDataTable;

    // 사망 프리팹
    [SerializeField] private GameObject _deathEffectPrefab;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _damagedAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Move();
    }

    protected abstract void Move();


    public void TakeDamage(float damage)
    {
        _health -= damage;

        // 피격 애니메이션
        _animator.SetTrigger("hit");
        if (_damagedAudioSource != null)
        {
            _damagedAudioSource.Play();
        }

        if (_health <= 0)
        {
            ScoreManager.Instance.AddScore(100);

            Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
            DropItem();

            Destroy(gameObject);
        }
    }

    private void DropItem()
    {
        float randomIndex = Random.value;
        if (randomIndex <= 0.3f)
        {
            // 아이템 랜덤 드랍 로직 변경 (SO 사용)
            SpawnRandomItem();
        }
    }

    private void SpawnRandomItem()
    {
        // 1. 전체 가중치 합산
        int totalWeight = 0;

        foreach (ItemSpawnData data in _spawnDataTable.Datas)
        {
            totalWeight += data.Weight;
        }

        // 2. 전체 가중치 범위에서 랜덤한 점수를 추첨
        int randomWeight = Random.Range(0, totalWeight);

        int cumulativeWeight = 0;
        foreach (ItemSpawnData data in _spawnDataTable.Datas)
        {
            cumulativeWeight += data.Weight;
            if (randomWeight < cumulativeWeight)
            {
                var item = ItemPool.Instance.GetItem(data.ItemType);
                item.transform.position = transform.position;
                break;
            }
        }
    }
}