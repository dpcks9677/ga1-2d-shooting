using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    public GameObject BulletPrefab;
    public Transform firePoint;
    // 스페이스바를 누를 때마다 총알 생성
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(BulletPrefab);
            bullet.transform.position = this.firePoint.position;
        }
    }
}
