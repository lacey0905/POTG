using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerInfo : MonoBehaviour {

    public string m_PlayerName;
    public int m_iPlayerIndex;

    public string PlayerName {
        get { return m_PlayerName; }
        set { m_PlayerName = value; }
    }

    public int PlayerIndex
    {
        get { return m_iPlayerIndex; }
        set { m_iPlayerIndex = value; }
    }

    void Start () {
		
	}
	
	void Update () {
		
	}
}
