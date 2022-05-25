using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Cannon001Controller : MonoBehaviour
{
    public float startHealth;

    public float bulletFireDelayTime;

    public static int level=1;

    public float healthRate;

    public GameObject rotateAxis;

    public GameObject mybullet;

    private bool isFire;

    private float fireReloadTime;

    public  GameObject firePosition;

    public Transform target;

    public ParticleSystem fireSmoke;

    private PhotonView pv;

    float health;

    public Image healthBar;

    public ParticleSystem dieParticle;

    private bool isDead;

    void Start()
    {
        isDead = false;
        health = startHealth + (healthRate * level);
        pv = GetComponent<PhotonView>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        StartCoroutine(FireDelay());
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
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <=3f)
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

    [PunRPC]
    void RPC_FireSmokeParticle()
    {
        fireSmoke.GetComponent<ParticleSystem>().Play();
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !isDead)
        {
            rotateAxis.transform.LookAt(target);
            isFire = true;
        }
        else if (target == null)
        {
            isFire = false;
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

    IEnumerator FireDelay()
    {
        while (true)
        {
            if (isFire && PhotonNetwork.IsMasterClient && !isDead)
            {
                PhotonNetwork.Instantiate(mybullet.name, firePosition.transform.position, firePosition.transform.rotation);
                pv.RPC("RPC_FireSmokeParticle", RpcTarget.All);
            }
            
            yield return new WaitForSeconds(bulletFireDelayTime);

            
        }
    }
}
