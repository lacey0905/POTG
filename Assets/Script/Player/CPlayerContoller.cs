using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerContoller : MonoBehaviour {

    public float m_fSpeed = 6.0f;   // 캐릭터 스피드

    Vector3 m_PlayerMovement;       //캐릭터 좌표
    Animator m_PlayerAnim;     // 애니메이션
    Rigidbody m_PlayerRigidBody;

    

    bool isMyPlayer = false;

    public void setMyPlayer() {
        isMyPlayer = true;
    }

    void Awake()
    {
        

        // 컴포넌트 가져오기
        m_PlayerAnim = GetComponent<Animator>();
        m_PlayerRigidBody = GetComponent<Rigidbody>();

        //Gun = GetComponentInChildren<Gun>();
    }


    void FixedUpdate() {

        //if (isMyPlayer)
        //{
        //    // 키 입력
        //    float h = Input.GetAxisRaw("Horizontal");
        //    float v = Input.GetAxisRaw("Vertical");

        //    // 캐릭터 이동
        //    setPlayerMovement(h, v);

        //    // 캐릭터 회전
        //    setPlayerTurning();

        //    // 캐릭터 애니메이션
        //    Animating(h, v);
        //    /*
        //    if (Gun.getIsShoot())
        //    {
        //        m_PlayerAnim.SetBool("IsShoot", true);
        //    }
        //    else {
        //        m_PlayerAnim.SetBool("IsShoot", false);
        //    }\
        //    */
        //}
        
    }

    

    void Animating(float h, float v)
    {
        // 이동 여부 검사
        bool walking = h != 0f || v != 0f;

        // 이동 애니메이션 실행
        m_PlayerAnim.SetBool("IsWalking", walking);
    }
}
