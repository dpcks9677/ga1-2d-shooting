using UnityEngine;

public class GuidedEnemy : Enemy
{
    private Vector2 _direction;
    public Vector3 playerPosition;
    public Transform targetTransform;

    private void Start()
    {
    }

    protected override void Move()
    {
        // 테스트를 위한 임시 변경
        _direction = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y)
            .normalized;

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