using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;
    
    private void Update()
    {
        Vector2 direction = Vector2.up;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
