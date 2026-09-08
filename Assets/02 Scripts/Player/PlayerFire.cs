using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // bullet 관련 오브젝트 변수
    public GameObject BulletPrefab;
    public GameObject subBulletPrefab;

    public Transform mainFirePointLeft;
    public Transform mainFirePointRight;

    public Transform subFirePointLeft;
    public Transform subFirePointRight;

    // bomb 관련 오브젝트 변수
    public GameObject BombPrefab;
    public Transform bombFirePoint;

    // 쿨다운 변수 집합
    public float bulletCooldown = 0.5f;
    private float bulletFireTimer = 0.5f;

    public float bombCooldown = 10.0f;
    private float bombFireTimer = 10.0f;

    private bool isAutoToggled = false;

    // 스페이스바를 누를 때마다 총알 생성
    private void Update()
    {
        bulletFireTimer += Time.deltaTime;
        bombFireTimer += Time.deltaTime;
        ToggleAutoFire();
        FireBullet();
        FireBomb();
    }

    private void FireBullet()
    {
        if (isAutoToggled)
        {
            if (bulletFireTimer >= bulletCooldown) LoadBullet();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && bulletFireTimer >= bulletCooldown) LoadBullet();
        }
    }

    private void FireBomb()
    {
        if (Input.GetKeyDown(KeyCode.B) && bombFireTimer >= bombCooldown)
        {
            {
                LoadBomb();
                Debug.Log("bomb");
                bombFireTimer = 0f;
            }
        }
    }

    private void LoadBullet()
    {
        var leftBullet = Instantiate(BulletPrefab);
        var rightBullet = Instantiate(BulletPrefab);

        var subLeftBullet = Instantiate(subBulletPrefab);
        var subRightBullet = Instantiate(subBulletPrefab);

        leftBullet.transform.position = mainFirePointLeft.position;
        rightBullet.transform.position = mainFirePointRight.position;

        subLeftBullet.transform.position = subFirePointLeft.position;
        subRightBullet.transform.position = subFirePointRight.position;

        bulletFireTimer = 0.0f;
    }

    private void LoadBomb()
    {
        var bomb = Instantiate(BombPrefab);
        bomb.transform.position = bombFirePoint.position;
    }

    private void ToggleAutoFire()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isAutoToggled == true)
                isAutoToggled = false;
            else
                isAutoToggled = true;
        }
    }

    public void ModifyFireRate(float newFireRate)
    {
        bulletCooldown = newFireRate;
    }
}