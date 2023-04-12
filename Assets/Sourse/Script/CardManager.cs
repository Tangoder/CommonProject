using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public GameObject A;
    public PhotonView pv;
    Vector3 pos = new Vector3(-36, -45, -2);
    public Text levelText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    void RPC_ScoreUpdate(int cost)
    {
        ScoreManager.monsterPoint -= cost; 
    }
    
    [PunRPC]
    void RPC_LevelUpdate()
    {
        A.GetComponent<CharacterData>().myData.level += 1;
    }

    public void Summon()
    {
        if (ScoreManager.monsterPoint >= A.GetComponent<CharacterData>().myData.cost)
        {
            //coldDown = true;
            pv.RPC("RPC_ScoreUpdate", RpcTarget.All, A.GetComponent<CharacterData>().myData.cost);
            if (!PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate(A.name, pos, Quaternion.identity);
            }

        }
    }

    public void LevelUp()
    {
        if (ScoreManager.monsterPoint >= A.GetComponent<CharacterData>().myData.levelUpCost && A.GetComponent<CharacterData>().myData.level < A.GetComponent<CharacterData>().myData.maxLevel)
        {
            pv.RPC("RPC_ScoreUpdate", RpcTarget.All, A.GetComponent<CharacterData>().myData.levelUpCost);
            pv.RPC("RPC_LevelUpdate", RpcTarget.All);
            levelText.text = "Level:" + A.GetComponent<CharacterData>().myData.level;
        }
    }
}
