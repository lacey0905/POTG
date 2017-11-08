using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRayFloor : MonoBehaviour {
    public float m_fFloorHei = 1.6f;
    public void SetRayFloorPos(float _floorY)
    {
        transform.position = new Vector3(this.transform.position.x, _floorY + m_fFloorHei, this.transform.position.z);
    }

    private void Update()
    {

        Vector3 _pos = new Vector3(transform.position.x, 6.6f, transform.position.z);

        transform.position = _pos;
        transform.Rotate(0, 0, 0);
    }
}
