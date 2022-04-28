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

    private void Start()
    {
        gameOver = false;
        StartCoroutine(TimeDelay());
    }

    void Update()
    {
        secTimerText.text = secRoundTime.ToString() + ":";
        minTimerText.text = minRoundTime.ToString();
    }

    void ScenePause()
    {
        Time.timeScale = 0;
        matchSummaryPanel.SetActive(true);
        //turn off script and other work ,something setActive false and turn on match summary panel
    }

    IEnumerator TimeDelay()
    {
        while (true)
        {
            if (isDelay && !gameOver)
            {
                minRoundTime -= 1;
                if (minRoundTime == 0 && secRoundTime >0)
                {
                    secRoundTime -= 1;
                    minRoundTime += 59;
                }
                if (minRoundTime + secRoundTime == 0)
                {
                    gameOver = true;
                    PhotonNetwork.LeaveRoom();
                    ScenePause();
                }
            }

            isDelay = false;
            yield return new WaitForSeconds(1.0f);
            isDelay = true;
        }
    }
}
