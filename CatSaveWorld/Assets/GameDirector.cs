using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject timeText;
    GameObject openNumText;
    float time = 20.0f;
    int openNum = 15;
    // Start is called before the first frame update
    public void OpenCardNum()
    {
        this.openNum--;
    }
    void Start()
    {
        this.timeText = GameObject.Find("Time");
        this.openNumText = GameObject.Find("OpenNum");
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;
        this.timeText.GetComponent<Text>().text = "���� �ð�: " + this.time.ToString("F1") + "��";
        this.openNumText.GetComponent<Text>().text = "������ Ƚ�� : " + this.openNum.ToString() + "ȸ";
    }
}
