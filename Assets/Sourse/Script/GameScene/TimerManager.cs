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

    public GameObject winText;

    public GameObject loseText;

    public GameObject disconnection;

    PhotonView pv;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        gameOver = false;
        StartCoroutine(TimeDelay());
        secTimerText.text = secRoundTime.ToString() + ":";
        if (minRoundTime < 10)
        {
            minTimerText.text = "0" + minRoundTime.ToString();
        }
        else
        {
            minTimerText.text = minRoundTime.ToString();
        }
    }

    private void Update()
    {

    }
    void ScenePause()
    {
        //Time.timeScale = 0;
        matchSummaryPanel.SetActive(true);
        if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            disconnection.SetActive(true);
            winText.SetActive(true);
        }
        else
        {
            if (MainFort.isBroken ^ CreateAndJoinRoom.isFort)
            {
                winText.SetActive(true);
            }
            else
            {
                loseText.SetActive(true);
            }
        }
        
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
            pv.RPC("RPC_PointUp", RpcTarget.All);
            isDelay = false;
            yield return new WaitForSeconds(1.0f);
            isDelay = true;
        }
    }
    [PunRPC]
    void RPC_PointUp()
    {
        if (isDelay&&!gameOver)
        {
            ScoreManager.monsterPoint += 1;
            ScoreManager.fortPoint += 1;
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
            if (minRoundTime + secRoundTime == 0 || PhotonNetwork.CurrentRoom.PlayerCount==1 || MainFort.isBroken)
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
