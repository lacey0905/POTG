using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerContoller : MonoBehaviour {

    public  float   m_fSpeed = 6.0f;        // 캐릭터 스피드

    Vector3         m_PlayerMovement;       //캐릭터 좌표
    Animator        m_PlayerAnim;           // 애니메이션
    Rigidbody       m_PlayerRigidBody;

    public int m_iFloorMask;                           //  레이캐스트 좌표를 얻을 바닥
    public float m_fCamRayLength = 100f;                 //  레이캐스트 레이저 길이

    void Awake()
    {
        //m_PlayerMovement =  GetComponent<Transform>();
        m_PlayerRigidBody = GetComponent<Rigidbody>();
        m_PlayerAnim =  GetComponent<Animator>();

        // Floor 마스크 레이어
        m_iFloorMask = LayerMask.GetMask("Floor");
    }

    void FixedUpdate()
    {
        // 키 입력
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        SetPlayerMovement(h, v);
        SetPlayerTurning();
        SetPlayerAnimating(h, v);
    }

    // 캐릭터 이동 셋팅
    void SetPlayerMovement(float h, float v)
    {
        m_PlayerMovement.Set(h, 0f, v);
        m_PlayerMovement = m_PlayerMovement.normalized * m_fSpeed * Time.smoothDeltaTime;

        //transform.Translate(m_PlayerMovement);

        Vector3 temp = transform.position;

        transform.localPosition = new Vector3(temp.x + m_PlayerMovement.x, temp.y + m_PlayerMovement.y, temp.z + m_PlayerMovement.z);

        //m_PlayerRigidBody.MovePosition(transform.position + m_PlayerMovement);
    }

    public Vector3 RayPoint; 

    // 캐릭터 회전 레이캐스트
    void SetPlayerTurning()
    {
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

            RayPoint = playerToMouse;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // 캐릭터를 회전 함
            m_PlayerRigidBody.MoveRotation(newRotation);
        }
    }

    public Vector3 getRayPoint() {
        return RayPoint;
    }


    void SetPlayerAnimating(float h, float v)
    {
        // 이동 여부 검사
        bool walking = h != 0f || v != 0f;

        // 이동 애니메이션 실행
        m_PlayerAnim.SetBool("IsWalking", walking);
    }

    public void SetPlayerMove(Vector3 _moveTranform) { m_PlayerMovement = _moveTranform; }
    public Vector3 GetPlayerMove() { return m_PlayerMovement; }
    public float GetPlayerSpeed() { return m_fSpeed; }
}
