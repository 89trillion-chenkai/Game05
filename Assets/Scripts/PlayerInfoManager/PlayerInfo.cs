using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家信息
/// </summary>
public class PlayerInfo : MonoBehaviour
{
    public static int score; //玩家分数成绩
    public static int coinNumber; //玩家金币数量

    void Start()
    {
        score = 0;
        coinNumber = 0;
    }
}
