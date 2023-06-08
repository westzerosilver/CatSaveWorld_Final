using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // 회전 속도 
    public float rotSpeed = 200f;
    // 회전 값 변수 
    float mx = 0;
    //
    public float moveSpeed = 7f;
    // 캐릭터 컨트롤러 변수 
    CharacterController cc;
    // 중력 변수 
    float gravity = -20;
    // 수직 속력 변수 
    float yVelocity = 0;
    // 점프 변수
    float jumpPower = 10f;
    //
    bool isJumping = false;


    // Start is called before the first frame update
    void Start()
    {
        // 캐릭터 컨트롤러 변수 받아옴 
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 입력 받기 
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        // 회전값 변수에 마우스 입력 값 만큼 누적 
        mx += mouse_X * rotSpeed * Time.deltaTime;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        // 카메라 기준으로 방향 변경
        dir = Camera.main.transform.TransformDirection(dir);


        //
        if (cc.collisionFlags == CollisionFlags.Below)
        {
            if (isJumping)
            {
                isJumping = false;
                yVelocity = 0;
            }
        }
        //
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            yVelocity = jumpPower;
            isJumping = true;
        }

        // 캐릭터 수직 속도에 중력 값 적용 
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        // 이동 속도 맞춰 이동 
        cc.Move(dir * moveSpeed * Time.deltaTime);

    }
}
