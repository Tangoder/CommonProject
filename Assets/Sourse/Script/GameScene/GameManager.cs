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

    public Button normalClassButton;

    public Button fireClassButton;

    public Button laserClassButton;

    public GameObject normalPanel;

    public GameObject firePanel;

    public GameObject laserPanel;

    PhotonView pv;

    void Start()
    {
        pv = GetComponent<PhotonView>();
        humenClassButton.GetComponent<Image>().color = Color.white;
        monsterClassButton.GetComponent<Image>().color = Color.gray;
        antClassButton.GetComponent<Image>().color = Color.gray;
        animalClassButton.GetComponent<Image>().color = Color.gray;

        normalClassButton.GetComponent<Image>().color = Color.white;
        fireClassButton.GetComponent<Image>().color = Color.gray;
        laserClassButton.GetComponent<Image>().color = Color.gray;

        fortScore.text = "Score:" + ScoreManager.fortScore;
        fortPoint.text = "Point:" + ScoreManager.fortPoint;

        monsterScore.text = "Score:" + ScoreManager.monsterScore;
        monsterPoint.text = "Point:" + ScoreManager.monsterPoint;

        hidePanel(monsterSummonPanel);
        hidePanel(fortSummonPanel);

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

    [PunRPC]
    void RPC_MonsterScoreSyn(int cost)
    {
        monsterPoint.text = "Point:" + (ScoreManager.monsterPoint -= cost);
    }

    [PunRPC]
    void RPC_FortScoreSyn(int cost)
    {
        fortPoint.text = "Point:" + (ScoreManager.fortPoint -= cost);
    }

    public void SummonLittleWizard()
    {   
        if(ScoreManager.monsterPoint >= MonsterAttributeList.costOfLittleWizard)
        {
            pv.RPC("RPC_MonsterScoreSyn", RpcTarget.All, MonsterAttributeList.costOfLittleWizard);
            PhotonNetwork.Instantiate(enemy.name, pos, Quaternion.identity);
        }
        else
        {
            //send msg of point not enough
        }
        
    }

    public void PutNormalFort()
    {
        if (ScoreManager.fortPoint >= FortAttributeList.costOfNormalFort)
        {
            pv.RPC("RPC_FortScoreSyn", RpcTarget.All, FortAttributeList.costOfNormalFort);
            PutEnemy.fortNumber = 0;
            putFort = true;
            hidePanel(fortSummonPanel);
            //fortSummonPanel.SetActive(false);
            fortFloatButton.SetActive(true);
        }
        else
        {
            //
        }
        
    }

    public void PutFireFort()
    {
        if (ScoreManager.fortPoint >= FortAttributeList.costOfFireFort)
        {
            pv.RPC("RPC_FortScoreSyn", RpcTarget.All, FortAttributeList.costOfFireFort);
            PutEnemy.fortNumber = 1;
            putFort = true;
            hidePanel(fortSummonPanel);
            //fortSummonPanel.SetActive(false);
            fortFloatButton.SetActive(true);
        }
        else
        {
            //
        }

    }

    public void OnClickExit()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }

    void ShowPanel(GameObject _this)
    {
        _this.GetComponent<CanvasGroup>().alpha = 1;
        _this.GetComponent<CanvasGroup>().interactable = true;
        _this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void hidePanel(GameObject _this)
    {
        _this.GetComponent<CanvasGroup>().alpha = 0;
        _this.GetComponent<CanvasGroup>().interactable =false;
        _this.GetComponent<CanvasGroup>().blocksRaycasts =false;
    }
    public void OnClickMonsterCanel()
    {
        hidePanel(monsterSummonPanel);
        monsterFloatButton.SetActive(true);
        //monsterSummonPanel.SetActive(false);
    }

    public void OnClickFortCanel()
    {
        hidePanel(fortSummonPanel);
        fortFloatButton.SetActive(true);
        //fortSummonPanel.SetActive(false);
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

    public void OnClickNormalClass()
    {
        normalClassButton.GetComponent<Image>().color = Color.white;
        fireClassButton.GetComponent<Image>().color = Color.gray;
        laserClassButton.GetComponent<Image>().color = Color.gray;

        normalPanel.SetActive(true);
        firePanel.SetActive(false);
        laserPanel.SetActive(false);

    }

    public void OnClickFireClass()
    {
        normalClassButton.GetComponent<Image>().color = Color.gray;
        fireClassButton.GetComponent<Image>().color = Color.white;
        laserClassButton.GetComponent<Image>().color = Color.gray;

        normalPanel.SetActive(false);
        firePanel.SetActive(true);
        laserPanel.SetActive(false);

    }

    public void OnClickLaserClass()
    {
        normalClassButton.GetComponent<Image>().color = Color.gray;
        fireClassButton.GetComponent<Image>().color = Color.gray;
        laserClassButton.GetComponent<Image>().color = Color.white;

        normalPanel.SetActive(false);
        firePanel.SetActive(false);
        laserPanel.SetActive(true);

    }
}
