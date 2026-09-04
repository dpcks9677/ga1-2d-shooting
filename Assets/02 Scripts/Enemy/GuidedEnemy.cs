using UnityEngine;

public class GuidedEnemy : Enemy
{
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
    }
}