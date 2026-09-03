using UnityEngine;
using UnityEngine.UIElements;

public class LookupEnemy : Enemy
{
    private Vector2 direction;
    public Transform targetTransform;

    private void Start()
    {
        Vector3 playerPosition = targetTransform.position;
        direction = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y)
            .normalized;
    }

    private void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}