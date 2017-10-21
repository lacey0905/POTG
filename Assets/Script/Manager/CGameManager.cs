using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CGameManager : MonoBehaviour {

    // 임시 데이터
    int iCharIndex = 0;
    string sPlayerID = "Player1";

    public  List<GameObject> m_CharacterList;       //  캐릭터 리스트 (현재는 1개만 사용)
    public  List<GameObject> m_PlayerList;          //  플레이어 리스트

    //public CPlayerFollow m_Camera;            //  카메라

    private void Awake()
    {
        //m_Camera = m_Camera.GetComponent<CPlayerFollow>();
        
    }

    void Start()
    {
        //  지금은 임시 데이터를 사용함
        //m_iPlayerIndex = iCharIndex;                                        //  My 플레이어 인덱스 저장 
        //StartCoroutine(AddPlayer(iCharIndex, sPlayerID));     //  플레이어 생성
    }

    IEnumerator AddPlayer(int _character, string _name)
    {
        yield return new WaitForSeconds(0.5f);

        GameObject _object = Instantiate(m_CharacterList[_character], new Vector3(5f, 20f, 0), Quaternion.identity) as GameObject;

        m_PlayerList.Add(_object);  //  플레이어 리스트에 생성 된 플레이어 Add

        //m_Camera.SetPlayerFollow(_object.GetComponent<Transform>());
     
    }

    private void FixedUpdate()
    {
        


    }

   
}
