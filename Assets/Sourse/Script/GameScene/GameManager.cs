using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 pos;
    public static bool putFort;

    public GameObject monsterButton;
    public GameObject fortButton;
    void Start()
    {
        if (CreateAndJoinRoom.isMonster)
        {
            monsterButton.SetActive(true);
            fortButton.SetActive(false);
        }
        else if (CreateAndJoinRoom.isFort)
        {
            monsterButton.SetActive(false);
            fortButton.SetActive(true);
        }
    }
    public void SummonEnemy()
    {
        PhotonNetwork.Instantiate(enemy.name, pos,Quaternion.identity);
    }

    public void PressToPutFort()
    {
        putFort = true;
    }


}
