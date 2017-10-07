using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{


    GameObject testParticle = null;
    public GameObject bullet_eft;
    public GameObject bullet;
    public GameObject Laser;

    GameObject laser_;

    int m_iFloorMask;               // 레이캐스트 좌표를 얻을 바닥
    float m_fCamRayLength = 100f;   // 레이캐스트 레이저 길이

    //public GameObject eft;

    //public float delay = 1.0f;

    //public float effectDuration = 2.5f;
    //private float d;

    //void OnEnable()
    //{
    //    d = effectDuration;
    //}


    IEnumerator gunStop()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(testParticle);
    }


    void Awake() {
        // Floor 마스크 레이어
        m_iFloorMask = LayerMask.GetMask("Floor");
    }

    float dalayTimer = 0f;
    public float shootTime = 0.05f;

    bool IsShoot = false;

    public bool getIsShoot() {
        return IsShoot;
    }

    void Update()
    {

        

        if (Input.GetMouseButton(1))
        {

            // 마우스 포인터 받기
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 충돌 확인
            RaycastHit floorHit;

            // 바닥에 충돌하면 실행
            if (Physics.Raycast(camRay, out floorHit, m_fCamRayLength, m_iFloorMask))
            {
                // 마우스 포인터에서 캐릭터 거리
                Vector3 playerToMouse = floorHit.point;


                playerToMouse.x = 0f;
                playerToMouse.y = 0f;
                playerToMouse.z = playerToMouse.z;

                if (laser_ == null)
                {
                    laser_ = Instantiate(Laser, this.transform.position, Quaternion.identity) as GameObject;
                    laser_.transform.parent = this.transform;
                    laser_.transform.rotation = this.transform.rotation;
                }
                laser_.GetComponent<line>().setLastPos(playerToMouse);
            }
        } else {
            if (laser_) {
                Debug.Log("레이저 삭제");
                Destroy(laser_);
             }

        }


        // 버튼이 눌러졌을때
        if (Input.GetMouseButton(0))
            {
                 
                dalayTimer += Time.smoothDeltaTime;
                if (dalayTimer > shootTime)
                {

                Quaternion temp = this.transform.rotation;
                float yPos = Random.Range(-5.0f, 5.0f);
                float zPos = Random.Range(-5.0f, 5.0f);

                this.transform.Rotate(0, this.transform.rotation.y + yPos, 0);

                GameObject bt = Instantiate(bullet, this.transform.position, this.transform.rotation) as GameObject;

                this.transform.rotation = temp;

                //Debug.Log(xPos);

                //bt.transform.parent = this.transform;
                //bt.transform.rotation = this.transform.rotation;
                //bt.transform.rotation = new Quaternion(0, 90.0f, 0, 0);
                //bt.transform.Rotate(xPos, 0, zPos);
                //bt.transform.Rotate(0, 0, 0);

                IsShoot = true;

                dalayTimer = 0f;
                }

                // 파티클이 있고
                if (testParticle)
                {
                    //StopCoroutine("gunStop");  
                }
                // 파티클이 없다면 새로 만들어주구요
                else
                {

                    //GameObject particleObject = Instantiate(bullet_eft, this.transform.position, Quaternion.identity) as GameObject;

                    //particleObject.transform.parent = this.transform;
                    //particleObject.transform.rotation = this.transform.rotation;
                    
                    //particleObject.transform.Rotate(0, -180f, 0);

                    //testParticle = particleObject;

                }
            }
            else
            {
                if (testParticle) {
                    StartCoroutine("gunStop");
                }
            IsShoot = false;
        }
        
        //GameObject translation = this.gameObject.GetComponent<CFX_Demo_Translate>();
        //translation.enabled = true;

        /*
        delay -= Time.deltaTime;
        if (delay < 0f)
            GameObject.Destroy(this.gameObject);

        if (d > 0)
        {
            d -= Time.deltaTime;
            if (d <= 0)
            {
                this.GetComponent<ParticleSystem>().Stop(true);

                CFX_Demo_Translate translation = this.gameObject.GetComponent<CFX_Demo_Translate>();
                if (translation != null)
                {
                    translation.enabled = false;
                }
            }
        }
        */
    }
}
