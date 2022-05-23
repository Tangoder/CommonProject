using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Enemy : MonoBehaviour
{
    private Transform target;

    private int wavepointIndex = 0;

    public float speed;

    public int startHealth ;

    public int attackFortDamage;

    float health;

    public static int level;

    public GameObject hitParticle;

    public Image healthBar;

    public Animator _animator;

    public int normalBulletDamage;

    public int fireDamage;

    PhotonView pv;

    //public static bool isDead;

    void Start()
    {
        pv = GetComponent<PhotonView>();
        _animator = GetComponent<Animator>();
        wavepointIndex = 0;
        target = Waypoint.points[wavepointIndex];
        level = 1;
        health = startHealth;
    }

    private void FixedUpdate()
    {
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            _animator.SetBool("die", true);
            //isDead = true;
            StartCoroutine(DieDelay());
        }
        else
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Movement();
            }
            
        }
    }

    void Movement()
    {
        transform.LookAt(target); //rotate character
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(target.position, transform.position) <= 0.1f)
        {
            GoNextPoint();
        }
    }

    [PunRPC]
    void RPC_TakeDamage(int Damage)
    {   
        this.health -= Damage;
    }

    [PunRPC]
    void RPC_AttackFortDamage(int Damage)
    {
        MainFort.health -= Damage;
    }

    private void OnTriggerStay(Collider other)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (other.tag == "normalBullet")
            {
                if (!PhotonNetwork.IsMasterClient)
                {
                    PhotonNetwork.Instantiate(hitParticle.name, transform.position, Quaternion.identity);
                }
                pv.RPC("RPC_TakeDamage", RpcTarget.All, normalBulletDamage);
            }

            if (other.tag == "Fire")
            {
                //PhotonNetwork.Instantiate(hitParticle.name, transform.position, Quaternion.identity);
                pv.RPC("RPC_TakeDamage", RpcTarget.All, fireDamage);
            }
        }
        
    }

    IEnumerator DieDelay()
    {
        yield return new WaitForSeconds(1);
        if (!PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }

    void GoNextPoint()
    {
        if (wavepointIndex >= Waypoint.points.Length - 1)
        {
            //isDead = true;
            pv.RPC("RPC_AttackFortDamage",RpcTarget.All,attackFortDamage);
            if (!PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Destroy(gameObject);
            }
            return;
        }
        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];
    }

}
