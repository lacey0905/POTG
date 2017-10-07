using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour {

    LineRenderer lineRender;

    Vector3 lastPos;

	// Use this for initialization
	void Start () {
        lineRender = GetComponent<LineRenderer>();

        lineRender.SetPosition(0, new Vector3(0, 0, 0));
        lineRender.SetPosition(1, new Vector3(0, 0, 15f));
    }

    public void setLastPos(Vector3 _pos) {
        lastPos = _pos;
    }

    public void setDestory() {
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        
        Debug.Log(lastPos);
    }
}
