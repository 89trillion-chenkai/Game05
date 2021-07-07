using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家信息
/// </summary>
public class PlayerInfoManager : MonoBehaviour
{
    public static int score; //玩家分数成绩
    public static int coinNumber; //玩家金币数量
    [SerializeField] private GenerateReward contentImage; //奖励生成的的脚本，需拖拽
    [SerializeField] private ScoreAndRinkSet scoreAndRinkSet; //设置成绩和段位脚本

    void Start()
    {
        score = 0;
        coinNumber = 0;
    }

    //加分按钮绑定函数
    public void AddScoreButton()
    {
        if (score < 6000)
        {
            score += 100;

            if (score > 6000) //防止分数刷新后再加分数出现超出最高限制的情况
            {
                score = 6000;
            }
            
            scoreAndRinkSet.SetScoreAndRank(); //设置成绩和段位

            if (score >= 4200)
            {
                contentImage.IfGenerateReward(); //刷新奖励
            }
        }
    }
}
