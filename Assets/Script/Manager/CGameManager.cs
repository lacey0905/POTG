using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CGameManager : MonoBehaviour {

    public CPlayerFollow m_Camera;            // 카메라
    public GameObject m_MyPlayer;             // 로컬 플레이어
    
    CPlayerContoller m_MyController;

    void Awake()
    {

    }

    void Start()
    {
        // 스폰 된 캐릭터 중에 나 자신인거 가져와서 m_MyPlayer에 컨트롤러로 넣음
        // 지금은 없으니까 에디터에서 집어 넣음
        //m_MyPlayer = 

        // (임시)내 캐릭터의 컨트롤러를 받아옴
        m_MyController = m_MyPlayer.GetComponent<CPlayerContoller>();

        // 카메라 클래스에 자신 캐릭터를 타겟으로 잡도록 셋팅해 준다.
        m_Camera.CameraSetup(m_MyPlayer);
    }

    // 업데이트는 투사체 같은 특별한 경우가 아니면 게임 매니저에서만 돌린다. ex) 캐릭터 이동 / 공격 같은거
    void FixedUpdate()
    {
        // isLocal로 내 클라이언트만 실행함
        // 내 플레이어 프리팹 빼고 나머지 프리팹에 클래스 지우는 거 Unet에 있음
        // 키 입력 받기
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        m_MyController.SetPlayerMovement(h, v);         // 캐릭터 이동 실행
        m_MyController.SetPlayerTurning();              // 캐릭터 회전 실행
        m_MyController.SetPlayerAnimating(h, v);        // 캐릭터 애니메이션 실행

        // 마우스 우클릭 했을 때
        if (Input.GetMouseButton(1))
        {
            // 카메라 에임 모드 전환
            m_Camera.SetAimMode(true, m_MyController.getRayPoint());
        }
        else
        {
            // 카메라 에임 모드 해제
            m_Camera.SetAimMode(false, m_MyController.getRayPoint());

            // 카메라 회전 키 입력
            if (Input.GetKey("e")) { m_Camera.SetRotation(-1); }
            else if (Input.GetKey("q")) { m_Camera.SetRotation(1); }
        }
    }

    void LateUpdate()
    {
        if (m_MyPlayer != null)
        {
            // 카메라 이동
            m_Camera.SetTargetPos(m_MyPlayer.transform.position);
        }
    }
}
