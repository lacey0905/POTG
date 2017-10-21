using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerFollow : MonoBehaviour {

    public Transform m_Target;          // 카메라가 따라다닐 타겟 지정
    public float m_fSmoothing = 5.0f;   // 따라다닐 때 부드러운 정도

    Vector3 m_Offset;                   // 카메라 위치


    void Start()
    {
        // 카메라 위치와 타겟의 위치 계산
        m_Offset = new Vector3(0, 25f, -8f);
    }

    void FixedUpdate()
    {


        Vector3 RayPoint = m_Target.GetComponent<CPlayerContoller>().getRayPoint();

        Vector3 dPos = m_Target.position;

        Debug.Log(RayPoint);

        if (m_Target != null)
        {
            // 타겟을 기준으로 카메라 위치 조정

            Vector3 temp = m_Target.position - RayPoint;

            Vector3 targetCamPos = m_Target.position + m_Offset + RayPoint/2.5f;


            targetCamPos.y = m_Offset.y;

            // 카메라 위치를 부드럽게 조정 함
            transform.position = Vector3.Lerp(transform.position, targetCamPos, m_fSmoothing * Time.deltaTime);

            if (Input.GetKey("c"))
            {
                transform.RotateAround(transform.position, new Vector3(0.0f, -1.0f, 0.0f), 10f + Time.deltaTime);
            }

        }

        
    }



    public void SetPlayerFollow(Transform _player)
    {
        Debug.Log(_player);
        m_Target = _player;
    }



}
