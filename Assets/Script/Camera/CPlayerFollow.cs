using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerFollow : MonoBehaviour {


    public float m_fSmoothing = 10.0f;   // 따라다닐 때 부드러운 정도

    public Transform m_Target;          // 카메라가 따라다닐 타겟 지정
    Vector3 m_Offset;                   // 카메라 위치


    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObj;
    float rotX = 0.01f;
    float rotY = 0.0f;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

        m_Offset = new Vector3(0, 0, 0);
    }

    void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        Transform target = CameraFollowObj.transform;

        float step = CameraMoveSpeed * Time.smoothDeltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        Vector3 temp = Vector3.Lerp(transform.position, target.position, m_fSmoothing * Time.deltaTime);
        temp.y = m_Offset.y;

        transform.position = temp;

    }


    /// <summary>
    /// zoom  클래스 정리 해야함
    /// </summary>

    void FixedUpdate()
    {
        zoom zoom = GetComponentInChildren<zoom>();
        if (Input.GetMouseButton(1))
        {
            Camera cam = Camera.main;

            Vector3 targetCamPos;

            Vector3 RayPoint = m_Target.GetComponent<CPlayerContoller>().getRayPoint();

            targetCamPos = m_Target.position + RayPoint / 2.5f;
            targetCamPos.y = 0f;
            //transform.position = targetCamPos;
            //transform.position = Vector3.Lerp(targetCamPos, transform.position, m_fSmoothing * Time.smoothDeltaTime);
            
            zoom.transform.position = Vector3.Lerp(zoom.transform.position, targetCamPos, m_fSmoothing * Time.smoothDeltaTime);

        }
        else
        {

            zoom.transform.position = Vector3.Lerp(zoom.transform.position, transform.position, m_fSmoothing * Time.smoothDeltaTime);

            Debug.Log(zoom.transform.position);

            if (Input.GetKey("e"))
            {
                rotY += 100.0f * Time.smoothDeltaTime;
            }
            else if (Input.GetKey("q"))
            {
                rotY += -100.0f * Time.smoothDeltaTime;
            }

            Quaternion LocalRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            transform.rotation = LocalRotation;
        }
    }

    //public void SetPlayerFollow(Transform _player)
    //{
    //    Debug.Log(_player);
    //    m_Target = _player;
    //}
}
