using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerMove : MonoBehaviour {

    public float m_fSpeed = 6.0f;   // 캐릭터 스피드

    Transform m_PlayerMovement;       //캐릭터 좌표
    Animator m_PlayerAnim;     // 애니메이션
    Rigidbody m_PlayerRigidBody;

    void Awake()
    {
        m_PlayerMovement = this.GetComponent<Transform>();
        m_PlayerAnim = GetComponent<Animator>();
        m_PlayerRigidBody = GetComponent<Rigidbody>();
    }

    public void SetPlayerMove(Vector3 _moveTranform)
    {
        m_PlayerMovement.position = _moveTranform;
    }

    public Vector3 getPlayerMove() {
        return m_PlayerMovement.position;
    }

    public float getPlayerSpeed() {
        return m_fSpeed;
    }

    public void SetPlayerRotation(Quaternion _rotation) {
        m_PlayerMovement.rotation = _rotation;
    }

    public Quaternion GetPlayerRotation() {
        return m_PlayerMovement.rotation;
    }

    public void SetRun(bool _run) {
        m_PlayerAnim.SetBool("IsWalking", _run);
    }

    void Animating(float h, float v)
    {
        // 이동 여부 검사
        bool walking = h != 0f || v != 0f;

        // 이동 애니메이션 실행
        m_PlayerAnim.SetBool("IsWalking", walking);
    }
}
