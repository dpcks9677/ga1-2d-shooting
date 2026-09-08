using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public float bombDamage = 100f;
    public float bombRemainTime = 3f;
    private float bombTimer = 0.0f;


    private void Update()
    {
        bombTimer += Time.deltaTime;
        if (bombTimer >= bombRemainTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bomb 충돌함");

        //Bomb 삭제
        if (other.gameObject.CompareTag("Enemy"))
        {
            // GetComponent<Type>() -> 게임 오브젝트가 가지고 있는 컴포넌트를 참조
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (other.gameObject.CompareTag("Enemy"))
            {
                enemy.TakeDamage(bombDamage);
            }
        }
    }
}