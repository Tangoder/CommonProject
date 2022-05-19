using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TODOList
{
    //UI Rect Transform調整
    //退出房間state不同 -- 了解PUN state
    //分數 時間 傷害同步 -- Call RPC  prototype
    //玩家離開房間 雙方結算畫面 -- PhotonNetwork.CurrentRoom.PlayerCount==1 判斷房間人數
    //砲塔優先攻擊第一個 -- OntriggerStay & Exit add 跟remove List佇列 or 陣列迴圈 判斷距離最近的敵人
    //跟滑鼠互動 UI用Event Object用OnMouse
    //腳本優先權 -- Script Execution Order
    //UI召喚CD --用update去跑time.deltatime做計時器fill Image當跑條 但UI的setActive顯示隱藏會影響到腳本的運行 所以召喚的Panel改成Canvas Group去做開關顯示隱藏
    //sidebarUI
}
