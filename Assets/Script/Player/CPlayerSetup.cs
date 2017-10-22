using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerSetup : MonoBehaviour {

    public string m_PlayerID;
    public int m_iPlayerIndex;
    public GameObject m_Character;

    public void setPlayerID(string _id) { m_PlayerID = _id; }
    public void setPlayerIndex(int _index) { m_iPlayerIndex = _index; }
    public void setPlayerCharacter(GameObject _Character) { m_Character = _Character; }
}
