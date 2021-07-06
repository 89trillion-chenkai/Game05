using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 添加分数按钮绑定函数
/// </summary>
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private GenerateReward contentImage; //奖励生成的父物体的脚本，需拖拽

    //加分按钮绑定函数
    public void AddScoreButton()
    {
        if (PlayerInfo.score < 6000)
        {
            PlayerInfo.score += 100;

            if (PlayerInfo.score > 6000) //防止分数刷新后再加分数出现超出最高限制的情况
            {
                PlayerInfo.score = 6000;
            }
            
            GetComponent<ScoreAndRinkSet>().SetScoreAndRank(); //设置成绩和段位

            if (PlayerInfo.score >= 4200)
            {
                contentImage.IfGenerateReward(); //刷新奖励
            }
        }
    }
}
