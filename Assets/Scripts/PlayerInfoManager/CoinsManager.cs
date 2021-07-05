using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 领取金币按钮绑定函数，绑定在奖励预制体的按钮上，与分数脚本所需的拖拽物体有所冲突故拆成两个脚本
/// </summary>
public class CoinsManager : MonoBehaviour
{
    public bool buttonFlag; //是否点击标记
    
    //领取金币奖励按钮绑定函数
    public void AddCoinButton()
    {
        if (buttonFlag == false)
        {
            PlayerInfo.coinNumber += 100;
            buttonFlag = true; //标记更新，避免重复点击
            Debug.Log("金币数量为：" + PlayerInfo.coinNumber); //输出查看金币数量
        }
    }
}
