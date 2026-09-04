using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private const float MOVE_TIME = 1.0f;
    private float moveTimeCounter = 0.0f;

    private GameObject _player;
    private float _moveSpeed = 5.0f;

    private void Start()
    {
        // 플레이어 추적용
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Debug.Log("플레이어 태그를 가진 게임 오브젝트를 찾지 못했습니다.");
            return;
        }
    }

    private void Update()
    {
        moveTimeCounter += Time.deltaTime;
        if (moveTimeCounter >= MOVE_TIME)
        {
            MoveToPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TakeItem(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void MoveToPlayer()
    {
        if (_player == null)
        {
            return;
        }

        // 1. 방향을 구한다.
        Vector2 direction = _player.transform.position - transform.position;
        direction.Normalize();

        // 2. 방향과 속도에 맞게 이동한다.
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }

    protected abstract void TakeItem(GameObject target);
}