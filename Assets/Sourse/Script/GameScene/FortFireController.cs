using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class FortFireController : MonoBehaviour
{
    public GameObject fort;
    private GameObject enemy;
    public GameObject mybullet;
    private bool isFire;
    private float fireReloadTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (fireReloadTime >= 0.5 && isFire == true) //每0.5秒發射一次
        {
            PhotonNetwork.Instantiate(mybullet.name, transform.position, transform.rotation);
            fireReloadTime = 0;
        }
        isFire = false;
        fireReloadTime += Time.deltaTime;
    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            fort.transform.LookAt(other.transform);
            isFire = true;
        }
    }
}
