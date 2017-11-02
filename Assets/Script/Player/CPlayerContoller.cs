using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerContoller : MonoBehaviour {

    public float m_fSpeed = 6.0f;                   // 캐릭터 스피드

    Vector3         m_PlayerMovement;               // 캐릭터 좌표
    Animator        m_PlayerAnim;                   // 애니메이션

    Transform       m_MainCamera;                   // 메인 카메라
    Vector3         m_CameraMovePos;                // 카메라 기준 이동 방향

    public CWeaponManager m_Weapon;

    void Awake()
    {
        m_PlayerAnim =  GetComponent<Animator>();
        m_Weapon = GetComponentInChildren<CWeaponManager>();
    }

    public void SetMainCamera(Camera _main)
    {
        m_MainCamera = _main.GetComponent<Transform>();
    }

    // 우클릭
    public void SetAimModeActvie(Vector3 _mousePointPos)
    {
        m_Weapon.SetLaserActive(_mousePointPos);
    }

    // 우클릭 해제
    public void SetAimModeDis()
    {
        m_Weapon.SetLaserDis();
    }

    public void Attack(Vector3 _MousePos)
    {
        m_Weapon.Shooting(_MousePos);
    }

    // 캐릭터 이동 셋팅
    public void SetPlayerMovement(float h, float v)
    {
        // 방향키가 눌렸을 때
        if (h != 0 || v != 0) {
            // 좌우 버튼을 눌렀을 때
            if (h != 0) {
                m_CameraMovePos = new Vector3(m_MainCamera.right.x * h, 0, m_MainCamera.right.z * h);
                transform.position += m_CameraMovePos * m_fSpeed * Time.smoothDeltaTime;
            }
            // 상하 버튼을 눌렀을 때
            if (v != 0)
            {
                m_CameraMovePos = new Vector3(m_MainCamera.up.x * v, 0, m_MainCamera.up.z * v);
                transform.position += m_CameraMovePos * m_fSpeed * Time.smoothDeltaTime;
            }
        }
    }

    // 캐릭터 회전
    public void SetPlayerTurning(Vector3 _mousePos)
    {
        // 마우스 포인터에서 캐릭터 거리
        Vector3 playerToMouse = _mousePos - transform.position;
        playerToMouse.y = 0f;

        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

        transform.rotation = newRotation;
    }

    public void SetPlayerAnimating(float h, float v)
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
