using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StoneController : MonoBehaviour
{
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }


    void OnCollisionEnter(Collision other)
    {
        VillainMove VM = other.gameObject.GetComponent<VillainMove>();
        VM.HitVillain();
        Destroy(this.gameObject);
        //GetComponent<Rigidbody>().isKinematic = true;
        //GetComponent<ParticleSystem>().Play();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

