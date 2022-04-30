using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyObjectSystem : MonoBehaviour
{
    public GameObject fa;
    public  void OnClickBuy()
    {

    }

    public void OnClickBuyLittleWizard()
    {
        fa = gameObject.transform.parent.gameObject;
        if (ScoreManager.monsterPoint >= MonsterAttributeList.buyOfLittleWizard)
        {
            ScoreManager.monsterPoint -= MonsterAttributeList.buyOfLittleWizard;
            fa.SetActive(false);
        }
    }
}
