using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWeaponManager : MonoBehaviour {

    public LineRenderer m_Laser;

    void Awake() {
        m_Laser = GetComponentInChildren<LineRenderer>();
    }

    public void SetLaserActive(Vector3 _pointPos) {

        m_Laser.gameObject.SetActive(true);

        m_Laser.SetColors(Color.red, Color.yellow);
        m_Laser.SetWidth(0.05f, 0.05f);

        _pointPos.y = transform.position.y;

        //라인렌더러 처음위치 나중위치
        m_Laser.SetPosition(0, transform.position);
        m_Laser.SetPosition(1, _pointPos);
    }

    public void SetLaserDis()
    {
        m_Laser.gameObject.SetActive(false);
    }

}
