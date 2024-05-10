using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CDPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    //当玩家与唱片机的碰撞箱接触时执行的语句
    {
        //必须是玩家，而非别的什么怪物都能触发
        if(collision.GetComponent<Player>()  != null)
        {
            //表示人物处于可触发交互界面的区域内，显示按键提示
            UI.instance.SetWhetherShowInteractToolTip(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    //当玩家离开唱片机的碰撞箱范围时执行的语句
    {
        if (collision.GetComponent<Player>() != null)
        {
            //关闭按键提示
            UI.instance.SetWhetherShowInteractToolTip(false);

            //若离开时唱片机UI是开启的，则关闭
            if (UI.instance.cdPlayerUI.activeSelf)
                UI.instance.SwitchToUI(UI.instance.inGameUI);
        }
    }
}