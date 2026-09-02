using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 1.0f;
    
    private void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + bulletSpeed * Time.deltaTime);
    }
}
