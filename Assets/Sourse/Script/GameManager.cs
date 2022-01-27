using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 pos;
    public static bool putFort;
    public void SummonEnemy()
    {
        Instantiate(enemy, pos,Quaternion.identity);
    }

    public void PressToPutFort()
    {
        putFort = true;
    }
}
