using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerContoller : MonoBehaviour {

    public float m_fSpeed = 6.0f;   // 캐릭터 스피드

    Vector3 m_PlayerMovement;       //캐릭터 좌표
    Animator m_PlayerAnim;     // 애니메이션
    Rigidbody m_PlayerRigidBody;

    int m_iFloorMask;               // 레이캐스트 좌표를 얻을 바닥
    float m_fCamRayLength = 100f;   // 레이캐스트 레이저 길이


    Gun Gun;

    void Awake()
    {
        // Floor 마스크 레이어
        m_iFloorMask = LayerMask.GetMask("Floor");

        // 컴포넌트 가져오기
        m_PlayerAnim = GetComponent<Animator>();
        m_PlayerRigidBody = GetComponent<Rigidbody>();

        Gun = GetComponentInChildren<Gun>();
    }

    void FixedUpdate() {
        // 키 입력
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 캐릭터 이동
        setPlayerMovement(h, v);

        // 캐릭터 회전
        setPlayerTurning();

        // 캐릭터 애니메이션
        Animating(h, v);

        if (Gun.getIsShoot())
        {
            m_PlayerAnim.SetBool("IsShoot", true);
        }
        else {
            m_PlayerAnim.SetBool("IsShoot", false);
        }
    }

    // 캐릭터 이동 셋팅
    void setPlayerMovement(float h, float v) {
        m_PlayerMovement.Set(h, 0f, v);
        m_PlayerMovement = m_PlayerMovement.normalized * m_fSpeed * Time.smoothDeltaTime;
        m_PlayerRigidBody.MovePosition(transform.position + m_PlayerMovement);
    }

    void setPlayerTurning() {
        // 마우스 포인터 받기
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // 충돌 확인
        RaycastHit floorHit;

        // 바닥에 충돌하면 실행
        if (Physics.Raycast(camRay, out floorHit, m_fCamRayLength, m_iFloorMask))
        {
            // 마우스 포인터에서 캐릭터 거리
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // 캐릭터를 회전 함
            m_PlayerRigidBody.MoveRotation(newRotation);

        }

    }

    void Animating(float h, float v)
    {
        // 이동 여부 검사
        bool walking = h != 0f || v != 0f;

        // 이동 애니메이션 실행
        m_PlayerAnim.SetBool("IsWalking", walking);
    }
}
