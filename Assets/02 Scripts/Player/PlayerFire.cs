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
            if(fireTimer >= bulletCooldown)
            {
                LoadBullet();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && fireTimer >= bulletCooldown)
            {
                LoadBullet();
            }
        }
        
    }

    private void LoadBullet()
    {
        GameObject leftBullet = Instantiate(BulletPrefab);
        GameObject rightBullet = Instantiate(BulletPrefab);
                
        GameObject subLeftBullet = Instantiate(subBulletPrefab);
        GameObject subRightBullet = Instantiate(subBulletPrefab);
                
        leftBullet.transform.position = this.mainFirePointLeft.position;
        rightBullet.transform.position = this.mainFirePointRight.position;
                
        subLeftBullet.transform.position = this.subFirePointLeft.position;
        subRightBullet.transform.position = this.subFirePointRight.position;
                
        fireTimer = 0.0f;
    }

    private void ToggleAutoFire()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isAutoToggled == true)
            {
                isAutoToggled = false;
            }
            else
            {
                isAutoToggled = true;
            }
        }
    }
}
