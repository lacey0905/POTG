using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharManager : MonoBehaviour {

    public float m_fSpeed;              //  캐릭터 스피드
    public int m_iPlayerIndex;

    public GameObject s_Instance;

    CPlayerMove m_PlayerMove;

    // Use this for initialization
    void Start () {
        s_Instance = this.gameObject;

        m_PlayerMove = s_Instance.GetComponent<CPlayerMove>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
