﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float Speed = 3000.0f;
    public GameObject eft;

	void Start () {
        GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
        this.transform.Rotate(90f, 0, 0);
        StartCoroutine("Bullet_Destroy");
    }

    void Update() {
        this.transform.localScale += new Vector3(0.0f, 0.3f, 0.0f);
    }

    void OnTriggerEnter(Collider _col) {
        if (_col.tag == "object")
        {
            GameObject eft_ = Instantiate(eft, this.transform.position, this.transform.rotation) as GameObject;
            eft_.transform.parent = this.transform.parent;
            Destroy(this.gameObject);
        }
    }

    IEnumerator Bullet_Destroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

}
