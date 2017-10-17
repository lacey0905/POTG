using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CGameManager : MonoBehaviour {

    // 임시 데이터
    int iCharIndex = 0;
    int iPlayerIndex = 0;
    string sPlayerID = "Player1";

    int m_iPlayerIndex;                             //  내 게임 인덱스

    public  List<GameObject> m_CharacterList;       //  캐릭터 리스트 (현재는 1개만 사용)
    public  List<GameObject> m_PlayerList;          //  플레이어 리스트

    public  CPlayerFollow    m_MyCamera;            //  카메라
    public  CCharManager     m_MyPlayer;            //  My 캐릭터

    int     m_iFloorMask;                           //  레이캐스트 좌표를 얻을 바닥
    float   m_fCamRayLength = 100f;                 //  레이캐스트 레이저 길이


    private void Awake()
    {
        // Floor 마스크 레이어
        m_iFloorMask = LayerMask.GetMask("Floor");
        m_MyCamera = m_MyCamera.GetComponent<CPlayerFollow>();
    }

    void Start()
    {
        //  지금은 임시 데이터를 사용함
        m_iPlayerIndex = iCharIndex;                                        //  My 플레이어 인덱스 저장 
        StartCoroutine(AddPlayer(iCharIndex, iPlayerIndex, sPlayerID));     //  플레이어 생성
    }

    IEnumerator AddPlayer(int _character, int _player, string _name)
    {
        yield return new WaitForSeconds(0.5f);

        GameObject _object = Instantiate(m_CharacterList[_character], new Vector3(5f, 20f, 0), Quaternion.identity) as GameObject;

        m_PlayerList.Add(_object);  //  플레이어 리스트에 생성 된 플레이어 Add

        //  생성 된 플레이어 번호가 MY플레이어와 같으면
        if (_player == m_iPlayerIndex)
        {
            _player = m_iPlayerIndex;
            m_MyPlayer = _object.GetComponent<CCharManager>();
            m_MyCamera.SetPlayerFollow(m_PlayerList[_player].GetComponent<Transform>());
        }
    }


    private void FixedUpdate()
    {
        //  내 캐릭터가 생성 되면
        if (m_MyPlayer != null)
        {
            // 키 입력
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Vector3 move = MakePlayerMovement(h, v);
            m_playerMoveMent.SetPlayerMove(move);

            m_playerMoveMent.SetPlayerRotation(SetPlayerTurning());




            // 이동 여부 검사
            bool walking = h != 0f || v != 0f;
            m_playerMoveMent.SetRun(walking);

        }

    }

    //  My캐릭터 이동 벡터 생성
    Vector3 MakePlayerMovement(float _h, float _v)
    {
        Vector3 _moveVecter = new Vector3(_h, 0f, _v);
        _moveVecter = _moveVecter.normalized * m_playerMoveMent.getPlayerSpeed() * Time.smoothDeltaTime;

        return m_playerMoveMent.getPlayerMove() + _moveVecter;
    }


    Quaternion SetPlayerTurning()
    {
        // 마우스 포인터 받기
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // 충돌 확인
        RaycastHit floorHit;

        // 바닥에 충돌하면 실행
        if (Physics.Raycast(camRay, out floorHit, m_fCamRayLength, m_iFloorMask))
        {
            // 마우스 포인터에서 캐릭터 거리
            Vector3 playerToMouse = floorHit.point - m_playerMoveMent.GetComponent<Transform>().position;

            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            return newRotation;
            // 캐릭터를 회전 함
            //m_PlayerRigidBody.MoveRotation(newRotation);
        }
        return m_playerMoveMent.GetPlayerRotation();
    }
}
