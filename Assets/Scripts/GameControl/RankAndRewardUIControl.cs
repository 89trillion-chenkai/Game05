using UnityEngine;

/// <summary>
/// 段位信息界面显示、隐藏控制
/// </summary>
public class RankAndRewardUIControl : MonoBehaviour
{
    public GameObject viewImage; //信息的背景图片
    
    void Start()
    {
        viewImage.gameObject.SetActive(false);
    }

    //显示单位、分数界面
    public void ShowRankInfoUI()
    {
        if (viewImage.gameObject.activeSelf == false)
        {
            viewImage.gameObject.SetActive(true);
        }
    }
    
    //隐藏单位、分数界面
    public void CloseRankInfoUI( )
    {
        if (viewImage.gameObject.activeSelf == true)
        {
            viewImage.gameObject.SetActive(false);
        }
    }
}
