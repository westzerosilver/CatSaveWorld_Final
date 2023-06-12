using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    bool Round1_clear;
    bool Round2_clear;
    bool Round3_clear;
    GameObject thirdPersonCamera;

    // Start is called before the first frame update
    void Start()
    {
        Round1_clear = false;
        Round2_clear = false;
        Round3_clear = false;
        this.thirdPersonCamera = GameObject.Find("ThirdPersonCamera");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToClass()
    {
        SceneManager.LoadScene("New");
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(Camera.main);
        DontDestroyOnLoad(thirdPersonCamera);
    }

    public void MoveToOutside()
    {
        SceneManager.LoadScene("New2");
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(Camera.main);
        DontDestroyOnLoad(thirdPersonCamera);
    }

    public void MoveToRound2()
    {
        SceneManager.LoadScene("New");
        DontDestroyOnLoad(this.gameObject);
    }

    public void finishedRound2()
    {
        SceneManager.LoadScene("New2");
        DontDestroyOnLoad(this.gameObject);
    }



    public void Clear(int stage)
    {
        switch (stage)
        {
            case 1:
                Round1_clear = true;
                break;

            case 2:
                Round2_clear = true;
                break;

            case 3:
                Round3_clear = true;
                break;

        }
    }
}