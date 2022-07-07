using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _3_BaseImformations : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* ---------RugidBody에 관련된건 FixedUpdate를 사용하기를 권장하고있다(자동으로움직이는거같은거)
        1.RigidBody = 물리효과를 받기 위한 컴포넌트
        Mass =무게 무겁다고 중력효과가 더 받는건 아니다.
        is kinematic  물리 외부 효과를 무시. 메서드만 영향 받는다(가벼운물체와 무거운물체가충돌해도 가벼운물체가 is kinematic이면 안팅긴다)
        
        2.메테리얼
        texture 는 메테리얼에서 색고르는 알베도옆 박스에 끌어댕겨넣으면 적용된다.
        Tile  = 텍스쳐 반복횟수
        Emission = 발광 느낌? 빛이 물리적으로 나오는건 아님 빛을 내는거같은 느낌의 재질

        3.collider = 충돌체 효과를 받기 위한 컴포넌트 -> collider가 적용된이후 충돌은  collider 범위가 기준이된다
        4.Physics Material  탄성과 마찰을 다루는 물리적인 재질 적용하면 Collider에 들어간다
            bounciness -> 탄력성(0~1) bouncecoimbine->다음 바운스는 얼마나 팅길거냐
            friction -> 마찰력
         */
    }
}
