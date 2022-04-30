using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PeopleData : MonoBehaviour
{
    // Start is called before the first frame update
    [Serializable]
    public struct People
    {
        public int id;
        public string name;
        public int cost;
        public float life;
        public int attrbutes;
        public float running_speed;
    }

    [SerializeField]
    private People people;
    void Start()
    {
        
        
    }
}
