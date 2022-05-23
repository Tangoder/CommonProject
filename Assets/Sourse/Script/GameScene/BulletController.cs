using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class BulletController : MonoBehaviourPunCallbacks
{
    public float survivalTime = 3.0f;

    public float speed = 10.0f;

    void start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, survivalTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
