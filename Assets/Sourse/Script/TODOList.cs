using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TODOList
{   
    //各種PhotonNetwork的生成與破壞 都要多一個判斷是否為MasterClient所生成破壞 否則會出現另一方有Double資訊傳輸
    //UI Rect Transform調整
    //退出房間state不同 -- 了解PUN state
    //分數 時間 傷害同步 -- Call RPC  prototype
    //玩家離開房間 雙方結算畫面 -- PhotonNetwork.CurrentRoom.PlayerCount==1 判斷房間人數
    //砲塔優先攻擊第一個 -- OntriggerStay & Exit add 跟remove List佇列 or 陣列迴圈 判斷距離最近的敵人
    //跟滑鼠互動 UI用Event Object用OnMouse
    //腳本優先權 -- Script Execution Order
    //UI召喚CD --用update去跑time.deltatime做計時器fill Image當跑條 但UI的setActive顯示隱藏會影響到腳本的運行 所以召喚的Panel改成Canvas Group去做開關顯示隱藏
    //UI召喚CD cost不夠沒召喚也會執行轉動 -- cost成立後按下召喚後給予coldDown = true 去給CD腳本判斷
    //列舉給FireDelay的waitingTime 會導致接收延遲出現子彈出去沒打到敵人的現象 -- 依據選擇target的update去判斷敵人是否為null
    //Sever端生成傳送位置資訊到Client端 兩筆資訊會導致怪物移動lag 砲台發射兩顆子彈 以及 怪物承受兩次傷害 -- 判斷IsMasterClient
    //prefab pool
    //砲台方有主塔血量 勝利機制判斷
    //砲台生命(時間) -- timeCountDown + enemyHealthBar
    //升級系統
    //觸碰焦點 浮動UI顯示tips
    //砲塔升級後血量不同步 結束畫面會先吃中離判斷
    //給予屬性表的數值 inspector levelText 召喚按鈕 升級按鈕
}
