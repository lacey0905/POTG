using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour {

    public GameObject GameCamera;
    public GameObject[] m_PlayerArr;

    public int m_iPlayerIndex = 0; //내 캐릭터 고유 인덱스


    public GameObject[] m_Player;

    void Start() {

        for (int i=0; i < m_PlayerArr.Length; i++) {
            m_Player[i] = Instantiate(m_PlayerArr[i], new Vector3(5*i, 20f, 0), Quaternion.identity) as GameObject;
        }

        GameCamera.GetComponent<CPlayerFollow>().setPlayerFollow(m_Player[m_iPlayerIndex].GetComponent<Transform>());
        m_Player[m_iPlayerIndex].GetComponent<CPlayerContoller>().setMyPlayer();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
