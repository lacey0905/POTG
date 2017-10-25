using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class netTemp : NetworkBehaviour {

    
    public Text temp;

    [SyncVar]
    public float num;
	
	// Update is called once per frame
	void Update () {
        num += Time.deltaTime;
        temp.text = num.ToString();
    }
}
