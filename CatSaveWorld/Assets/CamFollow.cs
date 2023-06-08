using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // player의 CamPosition을 받아옴
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 카메라 위치를 CamPosition과 일치시킴 
        transform.position = target.position;
    }
}
