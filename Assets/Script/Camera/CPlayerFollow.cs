using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerFollow : MonoBehaviour {

    public Transform m_Target;          // 카메라가 따라다닐 타겟 지정
    public float m_fSmoothing = 5.0f;   // 따라다닐 때 부드러운 정도

    Vector3 m_Offset;                   // 타겟의 위치

    void Start()
    {
        // 카메라 위치와 타겟의 위치 계산
        m_Offset = new Vector3(0, 25f, -11f);
    }

    void FixedUpdate()
    {
        // 타겟을 기준으로 카메라 위치 조정
        Vector3 targetCamPos = m_Target.position + m_Offset;

        // 카메라 위치를 부드럽게 조정 함
        transform.position = Vector3.Lerp(transform.position, targetCamPos, m_fSmoothing * Time.deltaTime);
    }

    public void setPlayerFollow(Transform _player) {
        Debug.Log(_player);
        m_Target = _player;
    }

}
