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

    public Text fortPoint;

    public Text monsterPoint;

    public Button normalClassButton;

    public Button fireClassButton;

    public Button laserClassButton;

    public GameObject normalPanel;

    public GameObject firePanel;

    public GameObject laserPanel;

    public static bool coldDown;

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

        fortPoint.text = "Point:" + ScoreManager.fortPoint;
        monsterPoint.text = "Point:" + ScoreManager.monsterPoint;


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
        monsterPoint.text = "Point:" + ScoreManager.monsterPoint;
        fortPoint.text = "Point:" + ScoreManager.fortPoint;
    }
    /// <summary>
    /// Call RPC function
    /// </summary>
    [PunRPC]
    void RPC_MonsterBuy(int cost)
    {
        ScoreManager.monsterPoint -= cost;
    }

    [PunRPC]
    void RPC_FortBuy(int cost)
    {
        ScoreManager.fortPoint -= cost;
    }

    /// <summary>
    /// Class of monster
    /// </summary>
    public void SummonLittleWizard()
    {   
        if(ScoreManager.monsterPoint >= MonsterAttributeList.costOfLittleWizard)
        {
            coldDown = true;
            pv.RPC("RPC_MonsterBuy", RpcTarget.All, MonsterAttributeList.costOfLittleWizard);
            if (!PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate(enemy.name, pos, Quaternion.identity);
            }
            
        }
        else
        {
            //send msg of point not enough
        }
        
    }


    /// <summary>
    /// Class of fort 
    /// </summary>
    public void PutNormalFort()
    {
        if (ScoreManager.fortPoint >= FortAttributeList.costOfNormalFort)
        {
            coldDown = true;
            pv.RPC("RPC_FortBuy", RpcTarget.All, FortAttributeList.costOfNormalFort);
            PutFort.fortNumber = 0;
            putFort = true;
            HidePanel(fortSummonPanel);
            ShowPanel(fortFloatButton);
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
            coldDown = true;
            pv.RPC("RPC_FortBuy", RpcTarget.All, FortAttributeList.costOfFireFort);
            PutFort.fortNumber = 1;
            putFort = true;
            HidePanel(fortSummonPanel);
            ShowPanel(fortFloatButton);
        }
        else
        {
            //
        }

    }




    void ShowPanel(GameObject _this)
    {
        _this.GetComponent<CanvasGroup>().alpha = 1;
        _this.GetComponent<CanvasGroup>().interactable = true;
        _this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void HidePanel(GameObject _this)
    {
        _this.GetComponent<CanvasGroup>().alpha = 0;
        _this.GetComponent<CanvasGroup>().interactable = false;
        _this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }


    /// <summary>
    /// any OnClick button
    /// </summary>
    public void OnClickExit()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }

    public void OnClickMonsterCanel()
    {
        HidePanel(monsterSummonPanel);
        ShowPanel(monsterFloatButton);
    }

    public void OnClickFortCanel()
    {
        HidePanel(fortSummonPanel);
        ShowPanel(fortFloatButton);
    }

    public void OnClickHumenClass()
    {
        humenClassButton.GetComponent<Image>().color = Color.white;
        monsterClassButton.GetComponent<Image>().color = Color.gray;
        antClassButton.GetComponent<Image>().color = Color.gray;
        animalClassButton.GetComponent<Image>().color = Color.gray;

        ShowPanel(humenPanel);
        HidePanel(monsterPanel);
        HidePanel(antPanel);
        HidePanel(animalPanel);

    }

    public void OnClickMonsterClass()
    {
        humenClassButton.GetComponent<Image>().color = Color.gray;
        monsterClassButton.GetComponent<Image>().color = Color.white;
        antClassButton.GetComponent<Image>().color = Color.gray;
        animalClassButton.GetComponent<Image>().color = Color.gray;

        HidePanel(humenPanel);
        ShowPanel(monsterPanel);
        HidePanel(antPanel);
        HidePanel(animalPanel);
    }

    public void OnClickAntClass()
    {
        humenClassButton.GetComponent<Image>().color = Color.gray;
        monsterClassButton.GetComponent<Image>().color = Color.gray;
        antClassButton.GetComponent<Image>().color = Color.white;
        animalClassButton.GetComponent<Image>().color = Color.gray;

        HidePanel(humenPanel);
        HidePanel(monsterPanel);
        ShowPanel(antPanel);
        HidePanel(animalPanel);
    }

    public void OnClickAnimalClass()
    {
        humenClassButton.GetComponent<Image>().color = Color.gray;
        monsterClassButton.GetComponent<Image>().color = Color.gray;
        antClassButton.GetComponent<Image>().color = Color.gray;
        animalClassButton.GetComponent<Image>().color = Color.white;

        HidePanel(humenPanel);
        HidePanel(monsterPanel);
        HidePanel(antPanel);
        ShowPanel(animalPanel);
    }

    public void OnClickNormalClass()
    {
        normalClassButton.GetComponent<Image>().color = Color.white;
        fireClassButton.GetComponent<Image>().color = Color.gray;
        laserClassButton.GetComponent<Image>().color = Color.gray;

        ShowPanel(normalPanel);
        HidePanel(firePanel);
        HidePanel(laserPanel);

    }

    public void OnClickFireClass()
    {
        normalClassButton.GetComponent<Image>().color = Color.gray;
        fireClassButton.GetComponent<Image>().color = Color.white;
        laserClassButton.GetComponent<Image>().color = Color.gray;

        HidePanel(normalPanel);
        ShowPanel(firePanel);
        HidePanel(laserPanel);

    }

    public void OnClickLaserClass()
    {
        normalClassButton.GetComponent<Image>().color = Color.gray;
        fireClassButton.GetComponent<Image>().color = Color.gray;
        laserClassButton.GetComponent<Image>().color = Color.white;

        HidePanel(normalPanel);
        HidePanel(firePanel);
        ShowPanel(laserPanel);

    }
}
