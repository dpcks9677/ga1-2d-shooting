using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject subBulletPrefab;

    public Transform mainFirePointLeft;
    public Transform mainFirePointRight;

    public Transform subFirePointLeft;
    public Transform subFirePointRight;

    public float bulletCooldown = 0.5f;
    private float fireTimer = 0.0f;

    private bool isAutoToggled = false;

    // 스페이스바를 누를 때마다 총알 생성
    private void Update()
    {
        fireTimer += Time.deltaTime;
        ToggleAutoFire();
        FireBullet();
    }

    private void FireBullet()
    {
        if (isAutoToggled)
        {
            if (fireTimer >= bulletCooldown) LoadBullet();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && fireTimer >= bulletCooldown) LoadBullet();
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

        fireTimer = 0.0f;
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
}