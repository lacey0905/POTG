using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerFollow : MonoBehaviour {
    
    public Transform    m_Target;               // 카메라가 따라다닐 타겟 지정
    public Vector3      m_TargetPos;            // 타겟의 포지션
    public float        m_fSmoothing = 10.0f;   // 따라다닐 때 부드러운 정도

    private CPlayerContoller    m_TargetContoller;
    private Vector3             m_RayPoint;

    private Camera      m_MainCamera;
    private CPlayerAim  m_PlayerAim;
    private Transform   m_TargetFollowObj;
    private Vector3     m_targetCamPos;

    private float       m_AimRange = 2.5f;
    private float       m_RotateSpeed = 100.0f;
    private float       rotX = 0.0f;
    private float       rotY = 0.0f;

    void Start()
    {
        // 카메라 회전 각도 저장
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

        // 카메라가 따라다닐 오브젝트 받아오기
        CCameraTarget CameraTarget = m_Target.GetComponentInChildren<CCameraTarget>();
        m_TargetFollowObj = CameraTarget.GetComponent<Transform>();

        // 플레이어 에임 모드
        m_PlayerAim = GetComponentInChildren<CPlayerAim>();

        // 메인 카메라 가져오기
        m_MainCamera = Camera.main;

        // 레이캐스트 포인트 받기
        m_TargetContoller = m_Target.GetComponent<CPlayerContoller>();
    }

    void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        // 타겟의 포지션을 새로 받아옴
        m_TargetPos = m_Target.transform.position;

        // 새로운 포지션 생성
        Vector3 newCameraPos = Vector3.Lerp(transform.position, m_TargetPos, m_fSmoothing * Time.deltaTime);
        newCameraPos.y = 0f;

        // 새로운 포지션으로 적용
        transform.position = newCameraPos;
    }


    void FixedUpdate()
    {
        // 마우스 우클릭 했을 때
        if (Input.GetMouseButton(1))
        {
            // 레이캐스트 벡터 받아오기
            m_RayPoint = m_TargetContoller.getRayPoint();
            m_targetCamPos = m_Target.position + m_RayPoint / m_AimRange;
            m_targetCamPos.y = 0f;
            m_PlayerAim.transform.position = Vector3.Lerp(m_PlayerAim.transform.position, m_targetCamPos, m_fSmoothing * Time.smoothDeltaTime);
        }
        else
        {
            // 카메라 원래 장소로 리셋하기
            m_PlayerAim.transform.position = Vector3.Lerp(m_PlayerAim.transform.position, transform.position, m_fSmoothing * Time.smoothDeltaTime);

            if (Input.GetKey("e"))
            {
                rotY += m_RotateSpeed * Time.smoothDeltaTime;
            }
            else if (Input.GetKey("q"))
            {
                rotY += -m_RotateSpeed * Time.smoothDeltaTime;
            }

            Quaternion LocalRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            transform.rotation = LocalRotation;
        }
    }
}
