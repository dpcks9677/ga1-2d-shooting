using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f;
    public float maxHeightTop = 0f;
    public float maxHeightBottom = -5.0f;
    public float maxWidth = 2.4f;
    
    // 목적 : 키보드 입력에 따라 플레이어 이동처리
    // Update 함수는 특별한 명시가 없다면 최대한 많이 실행한다
    private void Update()
    {
        /*
        이동 구현 패턴
        1. 입력을 받는다
        2. 입력에 따라 방향을 구한다
        3. 방향과 속도에 따라 이동한다.
        */

        // 입력 받기
        float h = Input.GetAxisRaw("Horizontal"); // 왼/오른쪽 입력 상태에 따라 -1f ~ 1f 사이 값 반환
        float v = Input.GetAxisRaw("Vertical"); // 위/아래 입력 상태에 따라 -1f ~ 1f 사이 값 반환
        
        //Debug.Log($"h:{h}, v:{v}");
        
        // 방향 구하기
        Vector2 direction = new Vector2(h, v).normalized;

        Vector2 normalizedSpeed = (direction * speed); // 벡터의 길이를 1로 만든다 (정규화)
        
        //이동 구현 + Y값 제한
        if (transform.position.y <= 0 && transform.position.y >= -5)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else if (transform.position.y > 0)
        {
            transform.position = new Vector2(transform.position.x, maxHeightTop);
        }
        else if (transform.position.y < -5)
        {
            transform.position = new Vector2(transform.position.x, maxHeightBottom);
        }
        
        //X값 제한
        if (transform.position.x > 2.4)
        {
            transform.position = new Vector2(-maxWidth, transform.position.y);
        }
        else if (transform.position.x <= -2.4)
        {
            transform.position = new Vector2(maxWidth, transform.position.y);
        }
        
        //속도 상승/하락
    }
}
