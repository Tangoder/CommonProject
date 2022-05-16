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

    public float bulletFireDelayTime;

    public Transform target;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        myPos = GetComponent<Transform>().position;
        myPos.y += 0.4f;  //reset fort position
        StartCoroutine(FireDelay());
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <=15f)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    void Update()
    {
        
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !this.targetQ.Contains(other))
        {
            this.targetQ.Add(other);
        }

        if (this.targetQ.Count > 0 && GameObject.FindGameObjectWithTag("Enemy"))
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            transform.LookAt(enemy.transform);
            isFire = true;
        }

        if (Enemy.isDead)
        {
            this.targetQ.Remove(other);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        this.targetQ.Remove(other);
    }

    private void FixedUpdate()
    {
        
    }*/


    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            transform.LookAt(target);
            isFire = true;
        }

    }

    IEnumerator FireDelay()
    {
        while (true)
        {
            if (isFire) PhotonNetwork.Instantiate(mybullet.name, myPos, transform.rotation);
            isFire = false;
            yield return new WaitForSeconds(bulletFireDelayTime);
        }
    }
}
