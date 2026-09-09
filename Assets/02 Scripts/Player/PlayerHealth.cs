using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _health = 3;

    [SerializeField] private AudioSource _playerDeathSound;

    [SerializeField] private GameObject _playerDeathEffectPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _health--;
            Destroy(other.gameObject);
            if (_health <= 0)
            {
                Instantiate(_playerDeathEffectPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                PlayDeathSound();
            }
        }
    }

    public void ModifyHealth(int amount)
    {
        _health += amount;
    }

    public int ReturnHealth() => _health;

    public void PlayDeathSound()
    {
        _playerDeathSound.Play();
    }
}