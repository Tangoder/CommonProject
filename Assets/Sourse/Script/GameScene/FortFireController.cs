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
        if (fireReloadTime >= 0.5 && isFire == true) //�C0.5��o�g�@��
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
