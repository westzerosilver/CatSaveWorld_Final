using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{

    // 회전 속도 
    public float rotSpeed = 200f;
    // 회전 값 변수 
    float mx = 0;
    float my = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //마우스 입력 받기 
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        // 회전값 변수에 마우스 입력 값 만큼 누적 
        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;

        // 상하 이동 변수 값을 제: -90~90도 사이
        my = Mathf.Clamp(my, -90f, 90f);

        // 회전 방향으로 물체 회전
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
