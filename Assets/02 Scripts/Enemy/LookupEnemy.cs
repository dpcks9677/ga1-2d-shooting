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
        }

        _direction = _player.transform.position - transform.position;
        _direction.Normalize();
    }
    
    protected override void Move()
    {
        transform.Translate(_direction * _moveSpeed * Time.deltaTime);
    }
}