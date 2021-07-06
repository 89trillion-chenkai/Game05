using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 段位信息设置
/// </summary>
public class ScoreAndRinkSet : MonoBehaviour
{
    [SerializeField]
    private Text scoreText; //分数文本,需拖拽
    [SerializeField]
    private Text rankText; //段位文本,需拖拽
    [SerializeField]
    private RectTransform scoreTextRect; //分数文本的矩形属性,需拖拽
    private int rankLevel; //段位

    void Start()
    {
        rankText.gameObject.SetActive(false); //初始时隐藏段位文本
        rankLevel = 0;
    }

    //设置段位信息
    public void SetScoreAndRank()
    {
        int newScore = PlayerInfo.score; //记录分数
        scoreText.text = newScore.ToString(); //更新显示分数

        if (newScore < 4000) //只显示分数文本，分数文本居中
        {
            if (rankText.gameObject.activeSelf == true)
            {
                rankText.gameObject.SetActive(false);
                scoreTextRect.pivot = new Vector2(0.5f, 0.5f); //改变分数文本中心点
                scoreTextRect.anchoredPosition = Vector2.zero; //分数文本位置锚定背景中央
            }
        }
        else //显示段位文本和分数文本，通过改变分数文本的中心点再让其居中来空出一块位置给段位文本
        {
            if (rankText.gameObject.activeSelf == false)
            {
                rankText.gameObject.SetActive(true);
                scoreTextRect.pivot = new Vector2(0, 0.5f); //改变分数文本中心点
                scoreTextRect.anchoredPosition = Vector2.zero; //分数文本位置锚定背景中央，给段位显示空出一定位置
            }

            rankLevel = (newScore - 4000) / 1000 + 1; //计算段位
            rankText.text = rankLevel.ToString(); //设置段位
        }
    }
}
