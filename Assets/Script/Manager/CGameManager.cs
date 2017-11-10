using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour {

    static public List<CPlayerManager> m_NetworkPlayerList;
    static public CCameraManager m_CameraManager;          // 카메라 매니저


    public CCameraManager cam;


    //CPlayerContoller m_LocalPlayerController;       // 로컬 플레이어 컨트롤러

    //Vector3 m_RayMousePoint;                        // 마우스 레이캐스트 포인트

    //public CRayFloor m_RayFloor;                    // 메인 카메라의 레이캐스트와 충돌 체크할 Floor 

    void LateUpdate()
    {
        //if (m_Target != null)
        //{
        //    // 카메라가 로컬 플레이어를 따라 다님
        //    SetTargetPos(m_Target.transform.position);
        //}
    }

    public void SetCamera()
    {
        
    }

    void Start()
    {

        m_CameraManager = cam;

        //if(m_LocalPlayer != null)
        //{
        //    // 카메라 셋업
        //    m_CameraManager.Setup(m_LocalPlayer.GetPlayerAnchor());

        //    // 카메라 셋업을 하고 로컬 플레이어에게 카메라 매니저 전달
        //    //m_LocalPlayer.SetMainCamera(m_CameraManager);


        //}

        //// 로컬 플레이어 컨트롤러
        //m_LocalPlayerController = m_LocalPlayer.GetComponent<CPlayerContoller>();
        //m_LocalPlayerController.SetMainCamera(m_CameraManager.GetMainCamera());
    }





    bool isShut = true;

    IEnumerator conShut()
    {
        yield return new WaitForSeconds(1.0f);
        isShut = true;
    }

   

    //void FixedUpdate()
    //{
    //    // 이동 입력 받기
    //    float h = Input.GetAxisRaw("Horizontal");
    //    float v = Input.GetAxisRaw("Vertical");

    //    // 마우스 Ray 받기
    //    m_RayMousePoint = m_CameraManager.GetMousePoint();

    //    // 로컬 플레이어 행동
    //    m_LocalPlayerController.Move(h, v);                     // 캐릭터 이동 실행
        
    //    m_LocalPlayerController.SetPlayerAnimating(h, v);       // 캐릭터 애니메이션 실행

        

    //    // 마우스 우클릭 했을 때
    //    if (Input.GetMouseButton(1))
    //    {
    //        // RayFloor를 총구 기준으로 움직임 (조준을 정확하게 하기 위해)
    //        //m_RayFloor.SetRayFloorPos(m_LocalPlayer.transform.position.y);


    //        m_LocalPlayerController.SetSpeed(2f);

    //        m_LocalPlayerController.Turn(m_RayMousePoint);

    //        // 카메라 에임 모드 전환
    //        m_CameraManager.SetAimMode(m_RayMousePoint, 20.0f);
    //        m_LocalPlayerController.SetAimModeActvie(m_RayMousePoint);


    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            if (isShut)
    //            {
    //                isShut = false;
    //                m_LocalPlayerController.Attack(m_RayMousePoint);
    //                m_CameraManager.GetComponentInChildren<CCameraShake>().StartShake();
    //                StartCoroutine("conShut");
    //            }


    //        }
    //        Cursor.visible = false;
    //    }
    //    else
    //    {

    //        m_LocalPlayerController.SetSpeed(6f);
    //        m_LocalPlayerController.Turn(h, v);

    //        Cursor.visible = true;

    //        // 카메라 에임 모드 해제
    //        m_CameraManager.SetDisAimMode();
    //        m_LocalPlayerController.SetAimModeDis();

    //        // 카메라 회전 키 입력
    //        if (Input.GetKey("e")) { m_CameraManager.SetRotation(-1); }
    //        else if (Input.GetKey("q")) { m_CameraManager.SetRotation(1); }
    //    }
    //}

    //void LateUpdate()
    //{
    //    if (m_LocalPlayer != null)
    //    {
    //        // 카메라가 로컬 플레이어를 따라 다님
    //        m_CameraManager.SetTargetPos(m_LocalPlayer.transform.position);
    //    }
    //}
}
