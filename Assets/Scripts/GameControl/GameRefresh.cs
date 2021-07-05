﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 赛季刷新
/// </summary>
public class GameRefresh : MonoBehaviour
{
    public Transform content; //奖励生成的父物体，需拖拽
    [SerializeField]
    private int rewardNumber; //奖励数
    
    
    //赛季刷新按钮绑定函数
    public void GameRefreshButton()
    {
        if (PlayerInfo.score > 4000)
        {
            PlayerInfo.score = (PlayerInfo.score - 4000) / 2 + 4000; //计算刷新分数
            GetComponent<ScoreAndRinkSet>().SetScoreAndRank(); //刷新分数和段位显示
            content.GetComponent<GenerateReward>().UpdateLastScore(); //更新此脚本里的LastScore
            RefreshReward(); //刷新奖励
        }
    }
    
    //赛季刷新时刷新奖励
    private void RefreshReward()
    {
        rewardNumber = (PlayerInfo.score - 4000) / 200
                       - (PlayerInfo.score - 4000) / 1000; //计算此时应有奖励的个数
        int childCount = content.childCount; //获取之前已经生成的奖励数量
        
        for (int i = childCount -1; i >= rewardNumber; i--)
        {
            Destroy(content.GetChild(i).gameObject); //销毁刷新后在分数以上的奖励
        }
        
        for (int i = 0; i < content.childCount; i++)
        {
            //重置按钮的初始状态
            content.GetChild(i).GetComponent<CoinsManager>().buttonFlag = false;
        }
    }
}