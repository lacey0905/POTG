using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerFollow : MonoBehaviour {

    public  float               m_fSmoothing = 10.0f;       // 따라다닐 때 부드러운 정도
    public  Transform           m_Target;                   // 카메라가 따라다닐 타겟 지정
    private Vector3             m_TargetPos;                // 타겟의 포지션 값

    private CPlayerContoller    m_TargetContoller;  
    private Vector3             m_RayPoint;

    private Camera      m_MainCamera;               // 카메라
    private CPlayerAim  m_PlayerAim;                // Aim 컴포넌트
    private Vector3     m_targetCamPos = new Vector3(0, 0, 0);            // Aim 모드 카메라 위치

    private float       m_AimRange = 2.5f;          // Aim 범위
    private float       m_RotateSpeed = 100.0f;     // 회전 속도
    private float       rotX = 0.0f;                // 회전 X값
    private float       rotY = 0.0f;                // 회전 Y값

    void Start()
    {
        // 카메라 회전 각도 저장
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

        // 플레이어 에임 모드
        m_PlayerAim = GetComponentInChildren<CPlayerAim>();

        // 메인 카메라 가져오기
        m_MainCamera = GetComponentInChildren<Camera>();
    }

    // 카메라 셋팅
    public void CameraSetup(GameObject _target) {
        CCameraTarget _CameraTarget = _target.GetComponentInChildren<CCameraTarget>();
        m_Target = _CameraTarget.GetComponent<Transform>();

        // 레이캐스트 포인트 받기
        m_TargetContoller = _target.GetComponent<CPlayerContoller>();
    }

    // 카메라 위치 갱신
    public void SetTargetPos(Vector3 _targetPos)
    {
        // 타겟의 포지션을 새로 받아옴
        m_TargetPos = _targetPos;

        // 새로운 포지션 생성
        Vector3 newCameraPos = Vector3.Lerp(transform.position, m_TargetPos, m_fSmoothing * Time.deltaTime);
        newCameraPos.y = 0f;

        // 새로운 포지션으로 적용
        transform.position = newCameraPos;
    }

    Vector3 camRay;
           // (3,3)
    public void SetAimMode(bool AimModeSet, Vector3 _rayPoint)
    {
        if (AimModeSet) {


            camRay = _rayPoint - m_PlayerAim.transform.position;


            //카메라가 이동할 위치
            m_targetCamPos = camRay;







            //Vector3 _ray = _rayPoint - temp_ray; // (1,1)

            //first_ray = _rayPoint; // (3,3)

            //Vector3 inpRay = _rayPoint - m_Target.position;
            ////       (3.3)      (4.4)         (0.0)

            //m_targetCamPos = inpRay - _ray; //(1,1)

            //   (3.3)          (3.3)           (0.0)                

            //temp = _rayPoint - m_targetCamPos;

            m_targetCamPos.y = 0f;

            m_targetCamPos = m_targetCamPos / 2.5f;


            m_PlayerAim.transform.position = Vector3.Lerp(m_PlayerAim.transform.position, m_targetCamPos, m_fSmoothing * Time.smoothDeltaTime);

        }
        else
        {
            // 카메라 원래 장소로 리셋하기
            m_PlayerAim.transform.position = Vector3.Lerp(m_PlayerAim.transform.position, transform.position, m_fSmoothing * Time.smoothDeltaTime);
        }
    }

    public void SetRotation(int _dir)
    {
        rotY += m_RotateSpeed * Time.smoothDeltaTime * _dir;
        Quaternion LocalRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = LocalRotation;
    }
}
