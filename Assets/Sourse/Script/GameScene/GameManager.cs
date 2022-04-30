using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject enemy;

    public Vector3 pos;

    public static bool putFort;

    public GameObject monsterFloatButton;

    public GameObject monsterSummonPanel;

    public GameObject fortFloatButton;

    public GameObject fortSummonPanel;

    public Button humenClassButton;

    public Button monsterClassButton;

    public Button antClassButton;

    public Button animalClassButton;

    public GameObject humenPanel;

    public GameObject monsterPanel;

    public GameObject antPanel;

    public GameObject animalPanel;

    public Text fortScore;

    public Text fortPoint;

    public Text monsterScore;

    public Text monsterPoint;

    void Start()
    {
        humenClassButton.GetComponent<Image>().color = Color.white;
        monsterClassButton.GetComponent<Image>().color = Color.gray;
        antClassButton.GetComponent<Image>().color = Color.gray;
        animalClassButton.GetComponent<Image>().color = Color.gray;

        if (CreateAndJoinRoom.isMonster)
        {
            monsterFloatButton.SetActive(true);
            fortFloatButton.SetActive(false);
        }
        else if (CreateAndJoinRoom.isFort)
        {
            monsterFloatButton.SetActive(false);
            fortFloatButton.SetActive(true);
        }
    }

    private void Update()
    {
        fortScore.text = "Score:" + ScoreManager.fortScore;
        fortPoint.text = "Point:" + ScoreManager.fortPoint;

        monsterScore.text = "Score:" + ScoreManager.monsterScore;
        monsterPoint.text = "Point:" + ScoreManager.monsterPoint;
    }

    public void SummonEnemy()
    {   
        if(ScoreManager.monsterPoint >= MonsterAttributeList.costOfLittleWizard)
        {
            ScoreManager.monsterPoint -= MonsterAttributeList.costOfLittleWizard;
            PhotonNetwork.Instantiate(enemy.name, pos, Quaternion.identity);
        }
        else
        {
            //send msg point not enough
        }
        
    }

    public void PressToPutFort()
    {
        if (ScoreManager.fortPoint >= FortAttributeList.costOfNormalFort)
        {   

            ScoreManager.fortPoint -= FortAttributeList.costOfNormalFort;
            putFort = true;
            fortSummonPanel.SetActive(false);
            fortFloatButton.SetActive(true);
        }
        else
        {

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

    public void OnClickExit()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }

    public void OnClickMonsterCanel()
    {
        monsterFloatButton.SetActive(true);
        monsterSummonPanel.SetActive(false);
    }

    public void OnClickFortCanel()
    {
        fortFloatButton.SetActive(true);
        fortSummonPanel.SetActive(false);
    }

    public void OnClickHumenClass()
    {
        humenClassButton.GetComponent<Image>().color = Color.white;
        monsterClassButton.GetComponent<Image>().color = Color.gray;
        antClassButton.GetComponent<Image>().color = Color.gray;
        animalClassButton.GetComponent<Image>().color = Color.gray;

        humenPanel.SetActive(true);
        monsterPanel.SetActive(false);
        antPanel.SetActive(false);
        animalPanel.SetActive(false);

    }

    public void OnClickMonsterClass()
    {
        humenClassButton.GetComponent<Image>().color = Color.gray;
        monsterClassButton.GetComponent<Image>().color = Color.white;
        antClassButton.GetComponent<Image>().color = Color.gray;
        animalClassButton.GetComponent<Image>().color = Color.gray;

        humenPanel.SetActive(false);
        monsterPanel.SetActive(true);
        antPanel.SetActive(false);
        animalPanel.SetActive(false);
    }

    public void OnClickAntClass()
    {
        humenClassButton.GetComponent<Image>().color = Color.gray;
        monsterClassButton.GetComponent<Image>().color = Color.gray;
        antClassButton.GetComponent<Image>().color = Color.white;
        animalClassButton.GetComponent<Image>().color = Color.gray;

        humenPanel.SetActive(false);
        monsterPanel.SetActive(false);
        antPanel.SetActive(true);
        animalPanel.SetActive(false);
    }

    public void OnClickAnimalClass()
    {
        humenClassButton.GetComponent<Image>().color = Color.gray;
        monsterClassButton.GetComponent<Image>().color = Color.gray;
        antClassButton.GetComponent<Image>().color = Color.gray;
        animalClassButton.GetComponent<Image>().color = Color.white;

        humenPanel.SetActive(false);
        monsterPanel.SetActive(false);
        antPanel.SetActive(false);
        animalPanel.SetActive(true);
    }


}
