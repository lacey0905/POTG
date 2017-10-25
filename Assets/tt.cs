using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class tt : NetworkBehaviour {

    public Button tempUI;

    [SyncVar]
    public float temp = 2f;

    void Start()
    {
    }

    void Update() {
        if (isLocalPlayer) {
            if (Input.GetKeyDown("t")) {
                transform.position = new Vector3(temp, 1f, 1f);
                temp += 2f;
            }
        }
    }

}
