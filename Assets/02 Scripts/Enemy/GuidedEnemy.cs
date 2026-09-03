using UnityEngine;

public class GuidedEnemy : Enemy
{
    private Vector2 _direction;
    public Vector3 playerPosition;
    public Transform targetTransform;

    private void Start()
    {
        _direction = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y)
            .normalized;
    }

    protected override void Move()
    {
        playerPosition = targetTransform.position;
        _direction = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y)
            .normalized;

        transform.Translate(_direction * moveSpeed * Time.deltaTime);
    }

    private void Update()
    {
        Move();
    }
}