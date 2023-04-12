using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;

public class CharacterData : MonoBehaviour
{   
    [Serializable]
    public struct Data
    {
        public int cost;

        public int maxLevel;

        public int levelUpCost;

        public float speed;

        public float startHealth;

        public float attackFortDamage;

        public float healthRate;

        public float damageRate;

        public float speedRate;

        public float health;

        public int level;

        public GameObject hitParticle;

        public Image healthBar;

        public Animator _animator;

        public float normalBulletDamage;

        public float fireDamage;

    }

    public Data myData;

    void Start()
    {
        myData.level = 1;
    }

    private void Update()
    {
        
    }
}
