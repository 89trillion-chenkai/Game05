using UnityEngine;

/// <summary>
/// 段位信息界面显示、隐藏控制
/// </summary>
public class RankAndRewardUIControl : MonoBehaviour
{
    [SerializeField] private GameObject viewImage; //显示段位和分数信息的背景图片
    
    void Start()
    {
        viewImage.SetActive(false);
    }

    //显示段位、分数界面
    public void ShowRankInfoUI()
    {
        if (viewImage.activeSelf == false)
        {
            viewImage.SetActive(true);
        }
    }
    
    //隐藏段位、分数界面
    public void CloseRankInfoUI( )
    {
        if (viewImage.activeSelf == true)
        {
            viewImage.SetActive(false);
        }
    }
}
