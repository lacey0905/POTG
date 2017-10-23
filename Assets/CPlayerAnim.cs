using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerAnim : MonoBehaviour {

    protected Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    //rolling variables
    public float rollSpeed = 8;
    bool isRolling = false;
    public float rollduration;

    private void Update()
    {
        if (Input.GetKey("space"))
        {
            if (!isRolling)
            {
                CPlayerAnim temp = GetComponentInChildren<CPlayerAnim>();
                StartCoroutine(temp._Roll(1));
            }
        }
    }


    public IEnumerator _Roll(int rollNumber)
    {
        animator.SetTrigger("RollForwardTrigger");

        CPlayerContoller cp = GetComponentInParent<CPlayerContoller>();

        Transform temp = cp.GetComponent<Transform>();

        Debug.Log(temp.transform.position);

        Vector3 targetTemp = new Vector3(temp.transform.position.x * 1.5f, temp.transform.position.y, temp.transform.position.z * 1.5f);

        temp.transform.position = Vector3.MoveTowards(temp.transform.position, targetTemp, 5f * Time.deltaTime);


        isRolling = true;
        yield return new WaitForSeconds(rollduration);
        isRolling = false;
    }
}
