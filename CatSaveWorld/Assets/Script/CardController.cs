using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{

    int imgNum = 1;
    bool isOpen = false;
    Animator anim;
    GameObject director;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        this.director = GameObject.Find("GameDirector");
        transform.GetComponent<Renderer>().material.mainTexture = Resources.Load("BackImage") as Texture2D;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && GameManager.state == GameManager.STATE.IDLE)
        {

            CheckCard();
            this.director.GetComponent<GameDirector>().OpenCardNum();
        }
    }
    void CheckCard()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            string tag = hit.transform.tag;
            if (tag.Substring(0, 4) == "Card")
            {
                hit.transform.SendMessage("OpenCard", SendMessageOptions.DontRequireReceiver);

            }
        }
    }


    void OpenCard()
    {
        if (isOpen) return;
        isOpen = true;

        //카드번호 Substring() 문자열의 일부분을 추출하는 함수, 카드번호는 0~10까지 있으므로 문자 4번째부터 끝까지 추출한다.
        int cardNum = int.Parse(transform.tag.Substring(4));
        imgNum = (cardNum + 1) / 2;
        anim.Play("CardOpen");

        GameManager.cardNum = cardNum;
        GameManager.state = GameManager.STATE.HIT;

    }
    void CloseCard()
    {
        anim.Play("CardClose");
        isOpen = false;
    }
    void ShowImage()
    {
        transform.GetComponent<Renderer>().material.mainTexture = Resources.Load("Image" + imgNum) as Texture2D;
    }
    void HideImage()
    {
        transform.GetComponent<Renderer>().material.mainTexture = Resources.Load("BackImage") as Texture2D;
    }
    // Update is called once per frame

}

