using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillainMove : MonoBehaviour
{
    enum VillaninState
    {
        Idle,
        Run,
        GameOver
    }

    public Transform rotationCenter;    // 기준점 설정 

    public float rotationRadius = 6f;   // 원의 반지름 변수  
    public float angularSpeed = 2f;     // 회전 속도 변수 

    float posX, posZ, angle = 0f;       // 좌표 계산, 각도 변수

    float maxHP = 5f;                   // 최대 체력 변수
    float hp = 5f;                      // 현재 체력 변수 
    float hitDamage = 1f;               // 돌 맞았을 시 데미지 변수 

    VillaninState m_State;              // 상태 변수

    public Slider hpSlider;             //  hp슬라이더 변수 


    // Start is called before the first frame update
    void Start()
    {
        this.m_State = VillaninState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        // 슬라이더에 hp를 반영
        hpSlider.value = (float)hp / (float)maxHP;

        // 상태변수
        switch (m_State)
        {
            case VillaninState.Idle:
                Idle();
                break;

            case VillaninState.Run:
                Run();
                break;


            case VillaninState.GameOver:
                //GameOver();
                break;
        }
    }

    void Idle()
    {
        if (hp < 5)
        {
            m_State = VillaninState.Run;
        }
    }

    void Run()
    {
        if (hp != 0)
        {
            /*
            // cos, sin을 활용해 좌표 계산 
            posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
            posZ = rotationCenter.position.z + Mathf.Sin(angle) * rotationRadius;
            // 위치 조정 
            transform.position = new Vector3(posX, this.transform.position.y, posZ);
            // 각도 조정
            angle = angle + Time.deltaTime * angularSpeed;

            // 각도 변수가 360이 넘는다면 계산을 위해 다시 0으로 초기화  
            if (angle >= 360f) angle = 0f;*/
        }

        else if (hp == 0)
        {
            m_State = VillaninState.GameOver;
            GameOver();
        }
    }



    void GameOver()
    {
        Debug.Log("Game Over");
    }


    public void HitVillain()
    {

        hp -= hitDamage;
        Debug.Log(this.hp);
    }


}

