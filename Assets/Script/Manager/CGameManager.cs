using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CGameManager : MonoBehaviour {

    public  List<GameObject> m_PlayerList;      //  플레이어 리스트
    public CPlayerFollow m_Camera;            //  카메라

    private void Awake()
    {
        //m_Camera = GetComponent<CPlayerFollow>();
    }

    void Start()
    {
    }

    void FixedUpdate()
    {
    }
}
