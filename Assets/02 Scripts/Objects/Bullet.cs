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

    //충돌 관련 이벤트 (Enter -> Stay -> Exit)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌함");

        //Bullet 삭제
        Destroy(this.gameObject);

        //충돌 대상 삭제
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // GetComponent<Type>() -> 게임 오브젝트가 가지고 있는 컴포넌트를 참조
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.health -= bulletDamage;

            if (enemy.health <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}