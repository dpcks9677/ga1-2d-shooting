using UnityEngine;

public class GuidedEnemy : Enemy
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
    }

    protected override void Move()
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
        
        // 3. 오브젝트 회전
        _direction = _player.transform.position - transform.position;
        _direction.Normalize();

        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
    }
}