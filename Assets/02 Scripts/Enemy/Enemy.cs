using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum ItemType
{
    Fast,
    Heal,
    IncreaseFireRate
}

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    //todo: enemy가 공격당할 때 재생되는 피격 사운드 출력
    [SerializeField] private AudioSource _damagedAudioSource;
    [SerializeField] private AudioSource _deadAudioSource;

    [SerializeField] private float _health = 100f;
    [SerializeField] protected float _moveSpeed;

    [SerializeField] private Item[] _ItemPrefabs;

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
        _damagedAudioSource.Play();

        if (_health <= 0)
        {
            ScoreManager scoreManager = GameObject.FindAnyObjectByType<ScoreManager>();
            int score = scoreManager.GetScore();
            scoreManager.AddScore(100);
            
            Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            _deadAudioSource.Play();
            DropItem();
        }
    }

    private void DropItem()
    {
        float randomIndex = Random.value;
        Item item = null;

        if (randomIndex <= 0.3f)
        {
            ItemType randomType = (ItemType)Random.Range(0, _ItemPrefabs.Length);
            item = Instantiate(_ItemPrefabs[(int)randomType]);
        }

        item.transform.position = transform.position;
    }
}