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

    [SerializeField] private float _health = 100f;
    [SerializeField] protected float _moveSpeed;

    [SerializeField] private Item[] _ItemPrefabs;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
        _animator.Play("hit");

        if (_health <= 0)
        {
            Destroy(gameObject);
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