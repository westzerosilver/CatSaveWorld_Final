using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DialogueController DlgControl;
    public float speed = 5f;
    float h, v;



    void Update()
    {

        h = DlgControl.isAction ? 0 : Input.GetAxis("Horizontal");        // 가로축
        v = DlgControl.isAction ? 0 : Input.GetAxis("Vertical");          // 세로축
    }
    void FixedUpdate()
    {
        transform.position += new Vector3(h, 0, v) * speed * Time.deltaTime;
        //Ray

    }
    void OnCollisionStay(Collision collision)
    {
        if (Input.GetButtonDown("Jump"))
            DlgControl.Action(collision.gameObject);

    }
}
