using UnityEngine;
using UnityEngine.UIElements;

public class LookupEnemy : Enemy
{
    private Vector2 _direction;
    public Transform targetTransform;

    protected override void Move()
    {
        transform.Translate(_direction * moveSpeed * Time.deltaTime);
    }

    private void Start()
    {
        Vector3 playerPosition = targetTransform.position;
        _direction = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y)
            .normalized;
    }

    private void Update()
    {
        Move();
    }
}