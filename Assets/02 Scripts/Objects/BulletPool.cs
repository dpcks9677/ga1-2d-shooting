using System;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    // 싱글턴 패턴
    // 1. 전역적으로 접근이 가능함
    // 2. 인스턴스가 하나임을 보장한다.
    private static BulletPool _instance = null;
    public static BulletPool Instance => _instance;

    // 관리: 특정 데이터에 대한 무결성과 추가, 수정, 삭제 등과 관련된 로직을 말함

    private int _bestScore;

    private int _currentScore;
    // 오브젝트 풀링:
    // 오브젝트의 Pool에 게임 오브젝트를 미리 필요한 만큼 저장한 후
    // 필요할 때마다 꺼내서 사용하고 필요가 없으면 반환하는 식으로
    // 메모리 할당과 해제를 최소화해서 성능을 최적화한다.

    [Header("총알 프리팹")] [SerializeField] private Bullet _bulletPrefab;
    [Header("풀 사이즈")] [SerializeField] private int _poolSize = 50;

    private Bullet[] _pool;

    private void Awake()
    {
        // 중복 생성 방지 코드
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        // 풀 크기만큼의 배열 생성
        _pool = new Bullet[_poolSize];

        // 풀에 오브젝트 삽입
        for (int i = 0; i < _poolSize; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab, gameObject.transform);
            bullet.OnSpawn(); // 풀 안의 오브젝트는 비활성화
            _pool[i] = bullet;
        }
    }

    public Bullet GetBullet()
    {
        foreach (Bullet bullet in _pool)
        {
            if (bullet.gameObject.activeSelf == false) // Pool 안의 비활성화된 총알 탐색
            {
                bullet.gameObject.SetActive(true);
                return bullet;
            }
        }

        return null;
    }
}