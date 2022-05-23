using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class FireFortController : MonoBehaviour
{
    public int startHealth;

    public static int level;

    public GameObject rotateAxis;

    public GameObject mybullet;

    private bool isFire;

    private float fireReloadTime;

    private Vector3 myPos;

    public Transform target;

    public ParticleSystem fire;

    float health;

    public Image healthBar;

    public ParticleSystem dieParticle;

    private bool isDead;

    void Start()
    {
        isDead = false;
        health = startHealth;
        level = 1;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        myPos = GetComponent<Transform>().position;
        myPos.y += 0.5f;  //reset fort position
        StartCoroutine(LifeCountDown());
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= 3f)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            mybullet.GetComponent<ParticleSystem>().Stop();
        }

        healthBar.fillAmount = health / startHealth;
        if (health == 0)
        {
            isDead = true;
            if (!dieParticle.GetComponent<ParticleSystem>().isPlaying)
            {
                dieParticle.GetComponent<ParticleSystem>().Play();
            }
        }
        else if (health <= -1)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Destroy(gameObject);
            }
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (!mybullet.GetComponent<ParticleSystem>().isPlaying)
            {
                mybullet.GetComponent<ParticleSystem>().Play();
            }
            else if(target == null || isDead)
            {
                mybullet.GetComponent<ParticleSystem>().Stop();
            }
            rotateAxis.transform.LookAt(target);
            
        }

    }

    IEnumerator LifeCountDown()
    {
        while (true)
        {
            this.health -= 0.5f;
            yield return new WaitForSeconds(0.5f);
        }
    }

}
