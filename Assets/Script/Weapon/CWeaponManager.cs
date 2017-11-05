using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CWeaponManager : MonoBehaviour {

    public GameObject m_Bullet;
    public GameObject audio;

    public int m_BulletMAX;
    public int m_BulletCurrent;

    public bool isShut;

    public LineRenderer m_Laser;


    public GameObject LineArea;
    public Image Line;
    public Image RedLine;

    int obj;

    void Awake() {
        m_Laser = GetComponentInChildren<LineRenderer>();
        m_Laser.gameObject.SetActive(false);

        obj = LayerMask.GetMask("towerwall");
    }


    public int gunDamage = 1;
    public float fireRate = 0.25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;

    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;

    void Update()
    {

        Vector3 rayOrigin = transform.position;

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, this.transform.forward, out hit, weaponRange))
        {
            if (hit.rigidbody != null)
            {
                lineRay = hit.point;
            }
        }
    }


    public void Shooting(Vector3 _mousePos) {
        GameObject ins = Instantiate(m_Bullet, transform.position, transform.rotation) as GameObject;

        Vector3 playerToMouse = _mousePos - ins.transform.position;
        playerToMouse.y = 0f;

        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

        ins.transform.rotation = newRotation;

        GameObject sound = Instantiate(audio, transform.position, transform.rotation) as GameObject;
    }

    Vector3 line;
    Vector3 lineRay;

    float prevAngle;

    public void SetLaserActive(Vector3 _pointPos) {


        LineArea.SetActive(true);


        // 충돌 확인
        RaycastHit Hit;


        float length = Vector3.Distance(_pointPos, transform.position);
        //length = new Vector3(length.x, length.y, 0.0f);



        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mouse.y = 6f;


        Debug.Log(mouse + " : " + transform.position);

        //바닥에 충돌하면 실행


        if (Physics.Raycast(transform.position, transform.forward, out Hit, length))
        {

            Vector3 forward = transform.TransformDirection(Vector3.forward);

            //Debug.DrawRay(transform.position, mouse, Color.green);

            if (Hit.collider.tag == "object")
            {
                Debug.Log("충돌");
                Debug.Log(Hit.transform.position);

                Vector3 over = Camera.main.WorldToScreenPoint(Hit.point);

                Vector3 over3 = over - Input.mousePosition;

                over3 = new Vector3(over3.x, over3.y, 0.0f);

                RedLine.transform.localScale = new Vector3(transform.localScale.x, over3.magnitude / 100, transform.localScale.z);
                RedLine.transform.rotation = Quaternion.FromToRotation(Vector3.up, over3);

                LineArea.transform.position = Input.mousePosition;

                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 hitp = Camera.main.WorldToScreenPoint(Hit.point);

                Vector3 v3 = screenPos - hitp;

                v3 = new Vector3(v3.x, v3.y, 0.0f);

                Line.transform.localScale = new Vector3(transform.localScale.x, v3.magnitude / 100 * -1f, transform.localScale.z);
                Line.transform.rotation = Quaternion.FromToRotation(Vector3.up, v3);

                Line.transform.position = screenPos;

            }
        }
        else
        {


            

            Line.transform.position = Input.mousePosition;
            RedLine.transform.localScale = new Vector3(0, 0, 0);


            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);


            LineArea.transform.position = Input.mousePosition;


            Vector3 v3 = screenPos - Input.mousePosition;

            v3 = new Vector3(v3.x, v3.y, 0.0f);

            Line.transform.localScale = new Vector3(transform.localScale.x, v3.magnitude / 100, transform.localScale.z);
            Line.transform.rotation = Quaternion.FromToRotation(Vector3.up, v3);

        }
        
        //Line.transform.position = screenPos;

        //Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //Debug.Log(_pointPos);

        //Line.transform.rotation = Quaternion.Euler(0, 0, -1f * (_pointPos));
        //Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        //Vector3 screenPos2 = Camera.main.WorldToScreenPoint(_pointPos);
        //Vector3 rayOrigin = Camera.main.WorldToViewportPoint(transform.position);
        //Debug.Log(rayOrigin);
        //Line.transform.position = rayOrigin;
        //m_Laser.gameObject.SetActive(true);
        //m_Laser.SetColors(Color.red, Color.yellow);
        //m_Laser.SetWidth(0.05f, 0.05f);
        ////_pointPos.y = transform.position.y;
        //// 마우스 원래 지점
        //line = _pointPos - lineRay;

        //_pointPos = _pointPos - line;
        //_pointPos.y = transform.position.y;  
        //Vector3 rayOrigin = Camera.main.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
        //rayOrigin.y = transform.position.y;
        //Debug.Log(rayOrigin);

        ////라인렌더러 처음위치 나중위치
        //m_Laser.SetPosition(0, transform.position);
        //m_Laser.SetPosition(1, rayOrigin);
    }

    public void SetLaserDis()
    {

        LineArea.SetActive(false);

        m_Laser.gameObject.SetActive(false);
    }

}
