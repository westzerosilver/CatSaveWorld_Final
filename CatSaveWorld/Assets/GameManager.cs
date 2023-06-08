using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public Text TimeText, OpenNumText;
    //클릭한 카드 번호
    static public int cardNum;
    //직전의 카드 번호
    int lastNum = 0;
    //스테이지의 전체 카드 수
    int cardCnt;
    //카드 클릭 횟수
    int hitCnt = 0;
    //카드배열 카드 섞기용
    int[] arCards = new int[11];

    //게임 시작 시간
    float startTime = 0;
    //float stageTime;
    public enum STATE
    {
        START, HIT, WAIT, IDLE, CLEAR
    };
    static public STATE state = STATE.START;
    // Start is called before the first frame update
    void Start()
    {
        this.startTime += Time.deltaTime;
        //StartCoroutine(MakeStage());
    }
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case STATE.START:
                StartCoroutine(MakeStage());
                break;
            case STATE.HIT:
                CheckCard();
                break;


        }

        if (Input.GetMouseButtonDown(1))
        {
            Application.Quit();
        }
    }
    void CheckCard()
    {
        state = STATE.WAIT;
        if (lastNum == 0)
        {
            lastNum = cardNum;
            state = STATE.IDLE;
            return;
        }
        int img1 = (cardNum + 1) / 2;
        int img2 = (lastNum + 1) / 2;
        if (img1 != img2)
        {
            StartCoroutine(CloseTwoCards());
            lastNum = 0;
            state = STATE.IDLE;
            return;
        }
        hitCnt += 2;
        if (hitCnt == cardCnt)
        {
            state = STATE.CLEAR;
            return;
        }
        lastNum = 0;
        state = STATE.IDLE;
    }

    IEnumerator CloseTwoCards()
    {
        GameObject card1 = GameObject.FindWithTag("Card" + lastNum);
        GameObject card2 = GameObject.FindWithTag("Card" + cardNum);

        //카드 닫기
        yield return new WaitForSeconds(0.2f);
        card1.SendMessage("CloseCard", SendMessageOptions.DontRequireReceiver);
        card2.SendMessage("CloseCard", SendMessageOptions.DontRequireReceiver);

    }

    IEnumerator MakeStage()
    {
        state = STATE.WAIT;
        ShuffleCard();
        //시작 카드의 x좌표
        float startx = -10;
        float startZ = -5;

        //SetCaretPos(startx, startZ);

        //int n = 1;
        for (int i = 1; i <= 10; i++)
        {
            GameObject Card = Instantiate(Resources.Load("Prefabs/Card")) as GameObject;
            cardCnt++;

            Card.transform.position = new Vector3(startx, 0, startZ);
            //Card.tag = "Card" + i;

            Card.tag = "Card" + arCards[i];
            //n++;

            startx += 5;
            // Card.renderer.material.mainTexture = Resources.Load("BackImage");
            if (i == 5)
            {
                startx = -10;
                startZ = 0;
            }
            yield return new WaitForSeconds(0.025f);
        }


        state = STATE.IDLE;

    }
    void ShuffleCard()
    {
        for (int i = 1; i <= 10; i++)
        {
            arCards[i] = i;
        }
        for (int i = 1; i <= 5; i++)
        {
            int n1 = Random.Range(1, 11);
            int n2 = Random.Range(1, 11);

            int temp = arCards[n1];
            arCards[n1] = arCards[n2];
            arCards[n2] = temp;
        }
    }



}

