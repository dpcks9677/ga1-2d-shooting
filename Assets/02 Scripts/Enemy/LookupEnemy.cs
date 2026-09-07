using UnityEngine;
using UnityEngine.UIElements;

public class LookupEnemy : Enemy
{
    private Vector2 _direction;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Debug.Log("플레이어 태그를 가진 게임 오브젝트를 찾지 못했습니다.");
            return;
        }

        _direction = _player.transform.position - transform.position;
        _direction.Normalize();

        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
    }

    protected override void Move()
    {
        if (_player == null)
        {
            return;
        }

        transform.Translate(_direction * _moveSpeed * Time.deltaTime, Space.World);
    }
}