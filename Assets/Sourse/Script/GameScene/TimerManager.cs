using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class TimerManager : MonoBehaviourPunCallbacks
{
    public Text secTimerText;

    public Text minTimerText;

    public int secRoundTime;

    public int minRoundTime;

    bool isDelay = false;

    public static bool gameOver = false;

    public GameObject matchSummaryPanel;

    public GameObject fortSummonPanel;

    public GameObject monsterSummonPanel;

    public GameObject fortFloatButton;

    public GameObject monsterFloatButton;

    PhotonView pv;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        gameOver = false;
        StartCoroutine(TimeDelay());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Time.timeScale = 1;
        }


    }
    void ScenePause()
    {
        //Time.timeScale = 0;
        matchSummaryPanel.SetActive(true);
        fortSummonPanel.SetActive(false);
        monsterSummonPanel.SetActive(false);
        fortFloatButton.SetActive(false);
        monsterFloatButton.SetActive(false);
        //turn off script and other work ,something setActive false and turn on match summary panel
    }

    IEnumerator TimeDelay()
    {
        while (true)
        {
            pv.RPC("RPC_CountDown", RpcTarget.All);
            isDelay = false;
            yield return new WaitForSeconds(1.0f);
            isDelay = true;
        }
    }

    [PunRPC]
    void RPC_CountDown()
    {
        if (isDelay && !gameOver)
        {
            minRoundTime -= 1;

            secTimerText.text = secRoundTime.ToString() + ":";
            if (minRoundTime < 10)
            {
                minTimerText.text = "0" + minRoundTime.ToString();
            }
            else
            {
                minTimerText.text = minRoundTime.ToString();
            }


            
            if (minRoundTime == 0 && secRoundTime > 0)
            {
                secRoundTime -= 1;
                minRoundTime += 59;
            }
            if (minRoundTime + secRoundTime == 0 || PhotonNetwork.CurrentRoom.PlayerCount==1)
            {
                gameOver = true;
                PhotonNetwork.LeaveRoom();
                ScenePause();
            }
            
        }
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

}
