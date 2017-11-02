using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWeaponManager : MonoBehaviour {

    public GameObject m_Bullet;
    public GameObject audio;

    public int m_BulletMAX;
    public int m_BulletCurrent;

    public bool isShut;

    public LineRenderer m_Laser;

    void Awake() {
        m_Laser = GetComponentInChildren<LineRenderer>();
        m_Laser.gameObject.SetActive(false);
    }



    public void Shooting(Vector3 _mousePos) {
        GameObject ins = Instantiate(m_Bullet, transform.position, transform.rotation) as GameObject;

        Vector3 playerToMouse = _mousePos - ins.transform.position;
        playerToMouse.y = 0f;

        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

        ins.transform.rotation = newRotation;

        GameObject sound = Instantiate(audio, transform.position, transform.rotation) as GameObject;
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
