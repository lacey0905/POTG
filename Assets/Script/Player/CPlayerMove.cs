using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerMove : MonoBehaviour {

    public float m_fSpeed = 6.0f;   // 캐릭터 스피드

    Vector3 m_PlayerMovement;       //캐릭터 좌표
    Animator m_PlayerAnim;     // 애니메이션
    Rigidbody m_PlayerRigidBody;

    void Awake()
    {
        m_PlayerMovement = this.transform.position;
        m_PlayerAnim = GetComponent<Animator>();
        m_PlayerRigidBody = GetComponent<Rigidbody>();
    }

    public void setPlayerMove(Vector3 _moveTranform)
    {
        m_PlayerMovement = _moveTranform;
    }

    public Vector3 getPlayerMove() {
        return m_PlayerMovement;
    }

    public float getPlayerSpeed() {
        return m_fSpeed;
    }


    void Animating(float h, float v)
    {
        // 이동 여부 검사
        bool walking = h != 0f || v != 0f;

        // 이동 애니메이션 실행
        m_PlayerAnim.SetBool("IsWalking", walking);
    }
}
