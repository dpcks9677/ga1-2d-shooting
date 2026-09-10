using UnityEngine;

/*
유니티에서 제공하는 **속성(Attribute)**으로
"이 스크립트가 정상 동작하려면 해당 컴포넌트가 
반드시 같은 게임오브젝트에 함께 붙어 있어야 한다"고 
유니티 에디터에 명시하는 안전장치 문법
*/
[RequireComponent(typeof(PlayerMove))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerFire))]


public class PlayerFacade : MonoBehaviour
{
    // 1. 내부 서브시스템 캐싱
    private PlayerMove _playerMove;
    private PlayerHealth _playerHealth;
    private PlayerFire _playerFire;

    private void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
        _playerHealth = GetComponent<PlayerHealth>();
        _playerFire = GetComponent<PlayerFire>();
    }

    // 2. 단일 기능 위임
    // 화살표 문법은 중괄호와 return을 생략하고 한 줄로 표기하는 방법
    public void IncreaseSpeed(int amount) => _playerMove.ModifySpeed(amount);
    public void Heal(int amount) => _playerHealth.ModifyHealth(amount);
    public void IncreaseFireRate(float amount) => _playerFire.ModifyFireRate(amount);

    // 3. 다중 컴포넌트 일괄 조율
    public void OnDeath()
    {
        _playerMove.enabled = false;
        _playerFire.enabled = false;
    }
}