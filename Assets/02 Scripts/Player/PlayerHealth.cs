using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _health = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("접촉함");
        if (other.CompareTag("Enemy"))
        {
            _health--;
            Destroy(other.gameObject);
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}