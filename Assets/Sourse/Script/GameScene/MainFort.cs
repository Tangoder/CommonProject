using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class MainFort : MonoBehaviour
{
    public int startHealth;

    public static float health;

    public Image healthBar;

    public ParticleSystem dieParticle;

    private bool isDead;

    public static bool isBroken;

    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        healthBar.fillAmount = health / startHealth;
        if (health == 0)
        {
            if (!dieParticle.GetComponent<ParticleSystem>().isPlaying)
            {
                dieParticle.GetComponent<ParticleSystem>().Play();
            }
            isBroken = true;
        }
    }
}
