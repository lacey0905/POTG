using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CGameManager : MonoBehaviour {

    public CCameraManager m_CameraManager;          // 카메라 매니저
    public GameObject m_LocalPlayer;                // 로컬 플레이어
    CPlayerContoller m_LocalPlayerController;       // 로컬 플레이어 컨트롤러

    Vector3 m_RayMousePoint;                        // 마우스 레이캐스트 포인트

    public CRayFloor m_RayFloor;                    // 메인 카메라의 레이캐스트와 충돌 체크할 Floor 

    void Start()
    {
        // 카메라 셋업
        m_CameraManager.Setup(m_LocalPlayer.GetComponentInChildren<CPlayerAnchor>());

        // 로컬 플레이어 컨트롤러
        m_LocalPlayerController = m_LocalPlayer.GetComponent<CPlayerContoller>();
        m_LocalPlayerController.SetMainCamera(m_CameraManager.GetMainCamera());
    }

    bool isShut = true;

    IEnumerator conShut()
    {
        yield return new WaitForSeconds(1.0f);
        isShut = true;
    }

    void FixedUpdate()
    {
        // 이동 입력 받기
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 마우스 Ray 받기
        m_RayMousePoint = m_CameraManager.GetMousePoint();

        // 로컬 플레이어 행동
        m_LocalPlayerController.SetPlayerMovement(h, v);                // 캐릭터 이동 실행
        m_LocalPlayerController.SetPlayerTurning(m_RayMousePoint);      // 캐릭터 회전 실행
        m_LocalPlayerController.SetPlayerAnimating(h, v);               // 캐릭터 애니메이션 실행

        // RayFloor를 총구 기준으로 움직임 (조준을 정확하게 하기 위해)
        m_RayFloor.SetRayFloorPos(m_LocalPlayer.transform.position.y);

        // 마우스 우클릭 했을 때
        if (Input.GetMouseButton(1))
        {
            // 카메라 에임 모드 전환
            m_CameraManager.SetAimMode(m_RayMousePoint, 30.0f);
            m_LocalPlayerController.SetAimModeActvie(m_RayMousePoint);

            if (Input.GetMouseButtonDown(0))
            {
                if (isShut)
                {
                    isShut = false;
                    m_LocalPlayerController.Attack(m_RayMousePoint);
                    m_CameraManager.GetComponentInChildren<CCameraShake>().StartShake();
                    StartCoroutine("conShut");
                }
            }
        }
        else
        {
            // 카메라 에임 모드 해제
            m_CameraManager.SetDisAimMode();
            m_LocalPlayerController.SetAimModeDis();

            // 카메라 회전 키 입력
            if (Input.GetKey("e")) { m_CameraManager.SetRotation(-1); }
            else if (Input.GetKey("q")) { m_CameraManager.SetRotation(1); }
        }
    }

 

    void LateUpdate()
    {
        if (m_LocalPlayer != null)
        {
            // 카메라가 로컬 플레이어를 따라 다님
            m_CameraManager.SetTargetPos(m_LocalPlayer.transform.position);
        }
    }
}
