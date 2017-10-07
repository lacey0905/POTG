using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerState : MonoBehaviour {

    public int m_iPlayerHP = 100;

    public int getPlayerHP() {
        return m_iPlayerHP;
    }

    public void setPlayerHP(int _hp) {
        m_iPlayerHP += _hp;
    }

}
