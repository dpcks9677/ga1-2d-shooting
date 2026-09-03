using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public float moveSpeed = 1.0f;

    private void Update()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}