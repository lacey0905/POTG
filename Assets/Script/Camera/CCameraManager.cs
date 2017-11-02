using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCameraManager : MonoBehaviour {

    public Transform m_Target;              // 카메라가 따라다닐 타겟 지정
    public float m_fSmoothing = 10.0f;      // 따라다닐 때 부드러운 정도
    public float m_RotateSpeed = 100.0f;    // 카메라 회전 속도

    float rotX = 0.0f;                      // 회전 X값
    float rotY = 0.0f;                      // 회전 Y값

    int m_iFloorMask;                       // 레이캐스트 좌표를 얻을 바닥 레이어 인덱스

    Vector3 m_RayMousePoint;                // 마우스 포인터 위치
    Vector3 m_TargetPos;                    // 타겟의 포지션 값

    Camera m_MainCamera;                    // 메인 카메라
    CPlayerAim m_PlayerAim;                 // Aim 컴포넌트

    Vector3 m_targetCamPos = new Vector3(0, 0, 0);            // Aim 모드 카메라 위치

    public void Setup(CPlayerAnchor _target)
    {
        // 메인 카메라 셋팅
        m_MainCamera = GetComponentInChildren<Camera>();

        // Floor 마스크 레이어
        m_iFloorMask = LayerMask.GetMask("Floor");

        // 카메라 회전 각도 저장
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

        // 플레이어 에임 모드
        m_PlayerAim = GetComponentInChildren<CPlayerAim>();

        // 카메라가 따라다닐 타겟
        m_Target = _target.GetComponent<Transform>();
    }

    public Camera GetMainCamera()
    {
        return m_MainCamera;
    }

    public Vector3 GetMousePoint()
    {
        // 마우스 포인터 받기
        Ray camRay = m_MainCamera.ScreenPointToRay(Input.mousePosition);

        // 충돌 확인
        RaycastHit floorHit;

        //바닥에 충돌하면 실행
        if (Physics.Raycast(camRay, out floorHit, 100f, m_iFloorMask))
        {
            m_RayMousePoint = floorHit.point;
        }

        return m_RayMousePoint;
    }

    // 카메라 위치 갱신
    public void SetTargetPos(Vector3 _targetPos)
    {
        // 타겟의 포지션을 새로 받아옴
        m_TargetPos = _targetPos;

        // 새로운 포지션 생성
        m_TargetPos = Vector3.Lerp(transform.position, m_TargetPos, m_fSmoothing * Time.deltaTime);
        m_TargetPos.y = 0f;

        // 새로운 포지션으로 적용
        transform.position = m_TargetPos;
    }

    public void SetAimMode(Vector3 _rayPoint, float _aimClamp)
    {
        _rayPoint.x = Mathf.Clamp(_rayPoint.x, m_Target.position.x - _aimClamp, m_Target.position.x + _aimClamp);
        _rayPoint.z = Mathf.Clamp(_rayPoint.z, m_Target.position.z - _aimClamp, m_Target.position.z + _aimClamp);

        Vector3 camMove = m_PlayerAim.transform.position - m_Target.position;

        _rayPoint = _rayPoint - camMove;
        _rayPoint.y = 0f;

        m_PlayerAim.transform.position = Vector3.Lerp(m_PlayerAim.transform.position, _rayPoint, m_fSmoothing * Time.smoothDeltaTime);
    }

    public void SetDisAimMode()
    {
        // 카메라 원래 장소로 리셋하기
        m_PlayerAim.transform.position = Vector3.Lerp(m_PlayerAim.transform.position, transform.position, m_fSmoothing * Time.smoothDeltaTime);
    }

    public void SetRotation(int _dir)
    {
        rotY += m_RotateSpeed * Time.smoothDeltaTime * _dir;
        Quaternion LocalRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = LocalRotation;
    }
}
