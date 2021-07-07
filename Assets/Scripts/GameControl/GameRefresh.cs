using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 赛季刷新
/// </summary>
public class GameRefresh : MonoBehaviour
{
    [SerializeField] private Transform content; //奖励生成的父物体，需拖拽
    [SerializeField] private ScoreAndRinkSet scoreAndRinkSet; //刷新分数和段位所在的脚本，需拖拽
    [SerializeField] private GenerateReward generateReward; //需调用脚本里的LastScore，需拖拽
    private int rewardNumber; //奖励数
    private Vector3 contentPosition; //存储滑动框初始位置

    void Start()
    {
        contentPosition = content.position; //记录滑动框初始位置
    }

    //赛季刷新按钮绑定函数
    public void GameRefreshButton()
    {
        if (PlayerInfoManager.score > 4000)
        {
            PlayerInfoManager.score = (PlayerInfoManager.score - 4000) / 2 + 4000; //计算刷新分数
            scoreAndRinkSet.SetScoreAndRank(); //刷新分数和段位显示
            generateReward.UpdateLastRewardScoreAndNumber(); //更新上次奖励分数和奖励个数
            RefreshReward(); //刷新奖励
            content.position = contentPosition; //滑动框回到初始位置
        }
    }
    
    //赛季刷新时刷新奖励
    private void RefreshReward()
    {
        int childCount = content.childCount; //获取之前已经生成的奖励数量
        rewardNumber = (PlayerInfoManager.score - 4000) / 200 - (PlayerInfoManager.score - 4000) / 1000; //计算此时应有奖励的个数

        for (int i = childCount -1; i >= rewardNumber; i--)
        {
            Destroy(content.GetChild(i).gameObject); //销毁赛季刷新后在当前分数以上的奖励
        }
        
        for (int i = 0; i < content.childCount; i++) //重置还存在的所有奖励领取按钮的状态
        {
            content.GetChild(i).GetComponent<RewardButtonManager>().RevertCoinButton(); //重制按钮状态
        }
    }
}
