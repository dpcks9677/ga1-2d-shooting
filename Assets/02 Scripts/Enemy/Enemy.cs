using UnityEngine;

public enum ItemType
{
    Fast,
    Heal,
    IncreaseFireRate
}

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    [SerializeField] protected float _moveSpeed;

    [SerializeField] private Item[] _ItemPrefabs;

    private void Update()
    {
        Move();
    }

    protected abstract void Move();


    public void TakeDamage(float damage)
    {
        _health -= damage;
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