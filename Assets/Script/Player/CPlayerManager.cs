using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerManager : CCameraManager {

    CPlayerContoller m_Controller;       // 로컬 플레이어 컨트롤러

    Vector3 m_RayPoint;                        // 마우스 레이캐스트 포인트

    public CRayFloor m_RayFloor;                    // 메인 카메라의 레이캐스트와 충돌 체크할 Floor 


    void Awake()
    {
        m_Controller = GetComponent<CPlayerContoller>();
    }

    void FixedUpdate()
    {

        //m_CameraManager.getR


        //if(isLocalPlayer)

        // 이동 입력 받기
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 마우스 Ray 받기
        //m_RayPoint = m_CameraManager.GetMousePoint();


        Debug.Log(GetMousePoint());



        // 로컬 플레이어 행동
        //m_LocalPlayerController.Move(h, v);                     // 캐릭터 이동 실행

        //m_LocalPlayerController.SetPlayerAnimating(h, v);       // 캐릭터 애니메이션 실행

        //// 마우스 우클릭 했을 때
        //if (Input.GetMouseButton(1))
        //{
        //    // RayFloor를 총구 기준으로 움직임 (조준을 정확하게 하기 위해)
        //    //m_RayFloor.SetRayFloorPos(m_LocalPlayer.transform.position.y);


        //    m_LocalPlayerController.SetSpeed(2f);

        //    m_LocalPlayerController.Turn(m_RayMousePoint);

        //    // 카메라 에임 모드 전환
        //    m_CameraManager.SetAimMode(m_RayMousePoint, 20.0f);
        //    m_LocalPlayerController.SetAimModeActvie(m_RayMousePoint);


        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        if (isShut)
        //        {
        //            isShut = false;
        //            m_LocalPlayerController.Attack(m_RayMousePoint);
        //            m_CameraManager.GetComponentInChildren<CCameraShake>().StartShake();
        //            StartCoroutine("conShut");
        //        }


        //    }
        //    Cursor.visible = false;
        //}
        //else
        //{

        //    m_LocalPlayerController.SetSpeed(6f);
        //    m_LocalPlayerController.Turn(h, v);

        //    Cursor.visible = true;

        //    // 카메라 에임 모드 해제
        //    m_CameraManager.SetDisAimMode();
        //    m_LocalPlayerController.SetAimModeDis();

        //    // 카메라 회전 키 입력
        //    if (Input.GetKey("e")) { m_CameraManager.SetRotation(-1); }
        //    else if (Input.GetKey("q")) { m_CameraManager.SetRotation(1); }
        //}
    }
}
