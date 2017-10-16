using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour {

    public CPlayerFollow m_Camera;

    public List<GameObject> m_CharacterList;
    public List<GameObject> m_PlayerList;

    public int m_iMyIndex = 0;

    CPlayerMove m_playerMoveMent;

    int m_iFloorMask;               // 레이캐스트 좌표를 얻을 바닥
    float m_fCamRayLength = 100f;   // 레이캐스트 레이저 길이

    /*
        서버 캐릭터 정보 구조
        
        int 캐릭터 종류 인덱스
        string 닉네임
        int 플레이어 인덱스

    */

    private void Awake()
    {

        // 서버에서 플레이어의 정보를 받아온다.
        // 받아온 정보 갯수만큼 돌림

        // Floor 마스크 레이어
        m_iFloorMask = LayerMask.GetMask("Floor");


        m_Camera = m_Camera.GetComponent<CPlayerFollow>();

        // 임시 데이터
        int CharacterIndex = 0;
        int playerIndex = 0;
        string playerName = "Player1";

        StartCoroutine(CreatePlayer(CharacterIndex, playerIndex, playerName));


        

    }


    private void FixedUpdate()
    {
        // 키 입력
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Debug.Log(m_playerMoveMent);

        if (m_playerMoveMent != null)
        {
            m_playerMoveMent.setPlayerMove(MakePlayerMovement(h, v));
        }
    }


    Vector3 MakePlayerMovement(float _h, float _v) {
        
        Vector3 _moveVecter = new Vector3(_h, 0f, _v);
        _moveVecter = _moveVecter.normalized * m_playerMoveMent.getPlayerSpeed() * Time.smoothDeltaTime;

        return m_playerMoveMent.getPlayerMove() + _moveVecter;
    }

    //// 캐릭터 이동 벡터 만들기
    //Vector3 createPlayerMovement(float h, float v)
    //{
    //    m_PlayerMovement.Set(h, 0f, v);
    //    m_PlayerMovement = m_PlayerMovement.normalized * m_fSpeed * Time.smoothDeltaTime;
    //    m_PlayerRigidBody.MovePosition(transform.position + m_PlayerMovement);
    //}

    void setPlayerTurning()
    {


        // 마우스 포인터 받기
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // 충돌 확인
        RaycastHit floorHit;

        // 바닥에 충돌하면 실행
        if (Physics.Raycast(camRay, out floorHit, m_fCamRayLength, m_iFloorMask))
        {
            // 마우스 포인터에서 캐릭터 거리
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // 캐릭터를 회전 함
            //m_PlayerRigidBody.MoveRotation(newRotation);

        }



    }

    IEnumerator CreatePlayer(int _characterIndex, int _playerIndex, string _playerName) {

        m_PlayerList.Add(Instantiate(m_CharacterList[_characterIndex], new Vector3(5f, 20f, 0), Quaternion.identity) as GameObject);
        CPlayerInfo _player = m_PlayerList[_playerIndex].GetComponent<CPlayerInfo>();

        _player.PlayerIndex = _playerIndex;
        _player.PlayerName = _playerName;


        // 임시 카메라 지정
        m_Camera.setPlayerFollow(m_PlayerList[_playerIndex].transform);


        m_playerMoveMent = m_PlayerList[m_iMyIndex].GetComponent<CPlayerMove>();


        yield return new WaitForSeconds(0.5f);
    }


    void Start() {

        //for (int i=0; i < m_PlayerArr.Length; i++) {
        //    m_Player[i] = Instantiate(m_PlayerArr[i], new Vector3(5*i, 20f, 0), Quaternion.identity) as GameObject;
        //}

        //GameCamera.GetComponent<CPlayerFollow>().setPlayerFollow(m_Player[m_iPlayerIndex].GetComponent<Transform>());
        //m_Player[m_iPlayerIndex].GetComponent<CPlayerContoller>().setMyPlayer();
    }

}
