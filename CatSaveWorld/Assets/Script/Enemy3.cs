using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy3 : MonoBehaviour
{
    enum Enemy3State
    {
        Idle,
        Run,
        Clear,
        GameOver
        
    }

    public Transform rotationCenter;    // 기준점 설정 

    public float rotationRadius = 6f;   // 원의 반지름 변수  
    public float angularSpeed = 2f;     // 회전 속도 변수 

    float posX, posZ, angle = 0f;       // 좌표 계산, 각도 변수

    float maxHP = 5f;                   // 최대 체력 변수
    float hp = 5f;                      // 현재 체력 변수 
    float hitDamage = 1f;               // 돌 맞았을 시 데미지 변수 

    Enemy3State m_State;              // 상태 변수

    public Slider hpSlider;             //  hp슬라이더 변수

    GameObject timeText;                // 시간 텍스트 
    float time = 60f;                   // 제한 시간 


    // Start is called before the first frame update
    void Start()
    {
        this.m_State = Enemy3State.Idle;
        this.timeText = GameObject.Find("Time");
    }

    // Update is called once per frame
    void Update()
    {

        this.time -= Time.deltaTime;
        this.timeText.GetComponent<Text>().text = this.time.ToString("F1");

        if(this.time <= 0)
        {
            this.m_State = Enemy3State.GameOver;
        }

        // 슬라이더에 hp를 반영
        hpSlider.value = (float)hp / (float)maxHP;

        // 상태변수
        switch (m_State)
        {
            case Enemy3State.Idle:
                Idle();
                break;

            case Enemy3State.Run:
                Run();
                break;

            case Enemy3State.Clear:
                //Clear();
                break;

            case Enemy3State.GameOver:
                //GameOver();
                break;
        }
    }

    void Idle()
    {
        if (hp < 5)
        {
            m_State = Enemy3State.Run;
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
            m_State = Enemy3State.GameOver;
            Clear();
        }
    }



    void Clear()
    {
        Debug.Log("Game Clear");
    }

    void GameOver()
    {
        // change scene
    }


    public void HitVillain()
    {

        hp -= hitDamage;
        Debug.Log(this.hp);
    }

}
