using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 控制奖励产生
/// </summary>
public class GenerateReward : MonoBehaviour
{
    [SerializeField] private Transform rewardPrefabs; //奖励预制体,需拖拽
    [SerializeField] private RectTransform contentRect; //滑动框的矩形属性,需拖拽
    [SerializeField] private GridLayoutGroup gridLayoutGroup; //滑动框的排列属性,需拖拽
    private int rewardNumber; //记录此分数下的奖励数
    private float height; //记录一个奖励条和一个间隔的长度
    private int lastRewardScore; //记录上次的分数
    private Vector3 contentPosition; //存储滑动框初始位置

    void Start()
    {
        rewardNumber = 0;
        height = gridLayoutGroup.cellSize.y + gridLayoutGroup.spacing.y; //一个奖励条和一个间隔的长度
        contentPosition = contentRect.position; //记录滑动框初始位置
    }

    //判断是否产生奖励
    public void IfGenerateReward()
    {
        if (PlayerInfoManager.score - lastRewardScore >= 200) //与上次获得奖励分数相差大于或等于200则更新
        {
            lastRewardScore = PlayerInfoManager.score - PlayerInfoManager.score % 200; //更新分数记录为上一个能产生奖励的数

            if (lastRewardScore % 1000 != 0) //不为整千则产生
            {
                GenerateRewardUI(); //产生奖励UI
                contentRect.position = contentPosition; //滑动框回到初始位置，防止滑动框滑上去了玩家注意不到奖励
            }
        }
    }

    //产生奖励UI
    private void GenerateRewardUI()
    {
        ++rewardNumber; //记录奖励个数
        contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, height * rewardNumber); //设置奖励列表长度
        Transform rewardInfo = Instantiate(rewardPrefabs, transform, false);
        rewardInfo.GetChild(0).GetComponent<Text>().text = lastRewardScore.ToString(); //设置奖励信息里的显示分数
    }

    //更新上次奖励分数和奖励个数
    public void UpdateLastRewardScoreAndNumber()
    {
        lastRewardScore = PlayerInfoManager.score - PlayerInfoManager.score % 200; //更新分数记录为上一个能产生奖励的数
        rewardNumber = (PlayerInfoManager.score - 4000) / 200 - (PlayerInfoManager.score - 4000) / 1000; //计算奖励条个数
    }
}
