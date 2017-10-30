using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRayFloor : MonoBehaviour {

    public float m_fFloorHei = 1.6f;

    public void SetRayFloorPos(float _floorY)
    {

        //Debug.Log(_floorY);

        transform.position = new Vector3(this.transform.position.x, _floorY + m_fFloorHei, this.transform.position.z);
    }
}
