using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;
    public float bulletDamage = 40f;

    private void Update()
    {
        Vector2 direction = Vector2.up;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("충돌함");

        //Bullet 삭제
        Destroy(this.gameObject);
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