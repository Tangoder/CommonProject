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

    private Vector3 myPos;

    public float bulletFireDelay;

    void Start()
    {
        myPos = GetComponent<Transform>().position;
        myPos.y += 0.4f;  //reset fort position
        StartCoroutine(FireDelay());
    }

    void Update()
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        /*if (fireReloadTime >= bulletFireDelay && isFire == true)
        {
            PhotonNetwork.Instantiate(mybullet.name, myPos, transform.rotation);
            fireReloadTime = 0;
        }
        isFire = false;
        fireReloadTime += Time.deltaTime;*/
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {   
            transform.LookAt(other.transform);
            isFire = true;
        }
    }

    IEnumerator FireDelay()
    {
        while (true)
        {   
            if(isFire) PhotonNetwork.Instantiate(mybullet.name, myPos, transform.rotation);
            isFire = false;
            yield return new WaitForSeconds(0.75f);
        }
    }
}
