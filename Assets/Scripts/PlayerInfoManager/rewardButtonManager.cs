using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 管理奖励按钮
/// </summary>
public class rewardButtonManager : MonoBehaviour
{
    [SerializeField] 
    private Image buttonImage; //按钮的图片
    private bool buttonFlag; //是否点击标记
    
    //领取金币奖励按钮绑定函数
    public void AddCoinButton()
    {
        if (buttonFlag == false)
        {
            PlayerInfo.coinNumber += 100;
            buttonFlag = true; //标记更新，避免重复点击
            buttonImage.color = Color.gray; //让按钮变色
        }
    }

    //初始化按钮
    public void RevertCoinButton()
    {
        buttonFlag = false; //标记状态恢复
        buttonImage.color = Color.white; //按钮颜色恢复
    }
}
