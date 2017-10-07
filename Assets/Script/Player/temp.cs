using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class temp : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;


    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>(); // 캐릭터 콘트롤러 참조
        if (controller.isGrounded)
        { // 땅에 있으면
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // 전후좌우 조정
            moveDirection = transform.TransformDirection(moveDirection); //축을 바꾼다. 월드 좌표로
            moveDirection *= speed;  // 움직임의 속도를 제어...
            if (Input.GetButton("Jump")) // 점프 버튼 누르면

                moveDirection.y = jumpSpeed;  // 해당 y값에 대입... 점프 한다.

        }
        moveDirection.y -= gravity * Time.deltaTime;  // y값에 조절 중력 가속도라고 보면 된다.
        controller.Move(moveDirection * Time.deltaTime);  // 콘트롤러는 이 모든 데이터를 참조하여 움직인다.. 시간 개념으로..
    }
}


