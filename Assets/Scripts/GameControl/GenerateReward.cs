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
    [SerializeField]
    private Transform rewardPrefabs; //奖励预制体,需拖拽
    [SerializeField]
    private RectTransform contentRect; //滑动框的矩形属性,需拖拽
    [SerializeField]
    private GridLayoutGroup gridLayoutGroup; //滑动框的排列属性,需拖拽
    private int rewardNumber; //记录此分数下的奖励数
    private float height; //记录一个奖励条和一个间隔的长度
    private int lastScore; //记录上次的分数

    void Start()
    {
        rewardNumber = 0;
        height = gridLayoutGroup.cellSize.y + gridLayoutGroup.spacing.y; //一个奖励条和一个间隔的长度
    }

    //判断是否产生奖励
    public void IfGenerateReward()
    {
        if (PlayerInfo.score - lastScore >= 200) //与上次分数相差大于或等于200则更新
        {
            lastScore = PlayerInfo.score - PlayerInfo.score % 200; //更新分数记录为上一个能产生奖励的数

            if (lastScore % 1000 != 0) //不为整千则产生
            {
                GenerateRewardUI(); //产生奖励UI
            }
        }
    }

    //产生奖励UI
    private void GenerateRewardUI()
    {
        ++rewardNumber; //记录奖励个数
        contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, height * rewardNumber); //设置奖励列表长度
        Transform rewardInfo = Instantiate(rewardPrefabs, transform, false);
        rewardInfo.GetChild(0).GetComponent<Text>().text = lastScore.ToString(); //设置奖励信息里的显示分数
    }

    //赛季刷新后更新之前的分数记录
    public void UpdateLastScore()
    {
        lastScore = PlayerInfo.score - PlayerInfo.score % 200; //更新分数记录为上一个能产生奖励的数
        rewardNumber = (PlayerInfo.score - 4000) / 200 - (PlayerInfo.score - 4000) / 1000; //计算奖励条个数
    }
}
