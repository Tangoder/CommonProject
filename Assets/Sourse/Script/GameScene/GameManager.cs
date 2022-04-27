using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
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

    public void OnClickExit()
    {
        
        //PhotonNetwork.LoadLevel("");
        //LoadScene
        PhotonNetwork.LeaveRoom();
    }
    //do these
    public override void OnLeftRoom()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }

}
