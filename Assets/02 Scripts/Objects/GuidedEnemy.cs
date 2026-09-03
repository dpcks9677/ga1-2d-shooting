using UnityEngine;

public class GuidedEnemy : Enemy
{
    private Vector2 direction;
    private Vector3 playerPosition;
    public Transform targetTransform;

    private void Start()
    {
        direction = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y)
            .normalized;
    }

    private void Update()
    {
        playerPosition = targetTransform.position;
        direction = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y)
            .normalized;

        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}