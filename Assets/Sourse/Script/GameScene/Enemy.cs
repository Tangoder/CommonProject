using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Enemy : MonoBehaviour
{
    public float speed = 10.0f;

    private Transform target;

    private int wavepointIndex = 0;

    public int startHealth ;

    float health;

    public GameObject hitParticle;

    public Image healthBar;

    [SerializeField]
    private Animator _animator;

    public float normalBulletDamage;

    PhotonView pv;

    public static bool isDead;

    void Start()
    {
        pv = GetComponent<PhotonView>();
        _animator = GetComponent<Animator>();
        wavepointIndex = 0;
        target = Waypoint.points[wavepointIndex];
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {   
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            _animator.SetBool("die", true);
            isDead = true;
            StartCoroutine(DieDelay());
        }
        else
        {
            transform.LookAt(target); //rotate character
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(target.position, transform.position) <= 0.1f)
            {
                GoNextPoint();
            }
        }
    }

    [PunRPC]
    void RPC_TakeDamage()
    {
        this.health -= normalBulletDamage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "normalBullet")
        {   
            PhotonNetwork.Instantiate(hitParticle.name, transform.position, Quaternion.identity);
            pv.RPC("RPC_TakeDamage", RpcTarget.All);
        }
    }

    IEnumerator DieDelay()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    void GoNextPoint()
    {
        if (wavepointIndex >= Waypoint.points.Length - 1)
        {
            isDead = true;
            PhotonNetwork.Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];
    }

}
