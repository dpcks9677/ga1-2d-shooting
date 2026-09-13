using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _health = 3;
    
    [SerializeField] private AudioSource _playerDamagedSound;
    [SerializeField] private GameObject _playerDeathEffectPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _health--;
            _playerDamagedSound.Play();
            other.gameObject.SetActive(false);
            if (_health <= 0)
            {
                Instantiate(_playerDeathEffectPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    public void ModifyHealth(int amount)
    {
        _health += amount;
    }

    public int ReturnHealth() => _health;
}