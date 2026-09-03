using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _health = 100;
    public float moveSpeed = 1.0f;

    private void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
    }

    public void TakeDamage(float bulletDamage)
    {
        _health -= bulletDamage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}