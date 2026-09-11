using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private BulletType _type;
    public BulletType Type => _type;

    public float speed = 1.0f;
    public float bulletDamage = 40f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnSpawn()
    {
        // 프리팹이 Pool에 의해 활성화 될 때마다
        // 초기화 하는 코드들이 들어간다
        PlaySound();
    }

    // 활성화 될 때마다 자동으로 호출되는 이벤트 함수
    private void PlaySound()
    {
        _audioSource.pitch = UnityEngine.Random.Range(-1f, 3f);
        _audioSource.Play();
    }


    private void Update()
    {
        Vector2 direction = Vector2.up;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Bullet Pool로 반환
        gameObject.SetActive(false);

        if (other.gameObject.CompareTag("Enemy"))
        {
            // GetComponent<Type>() -> 게임 오브젝트가 가지고 있는 컴포넌트를 참조
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (other.gameObject.CompareTag("Enemy"))
            {
                enemy.TakeDamage(bulletDamage);
            }
        }
    }
}