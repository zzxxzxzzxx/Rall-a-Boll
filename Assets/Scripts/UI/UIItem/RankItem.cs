using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 排名信息
/// </summary>
public class RankItem : MonoBehaviour
{
    #region 成员变量
    /// <summary>
    /// 排名编号
    /// </summary>
    [SerializeField]
    private Text rankID;

    /// <summary>
    /// 得分
    /// </summary>
    [SerializeField]
    private Text score;
    #endregion

    #region 提供的方法
    /// <summary>
    /// 设置面板信息
    /// </summary>
    /// <param name="rankID">排名编号</param>
    /// <param name="score">得分</param>
    public void SetRankInfo(int rankID, int score)
    {
        SetRankInfo(rankID.ToString(), score.ToString());
    }

    /// <summary>
    /// 设置面板信息重载
    /// </summary>
    /// <param name="rankID">排名编号</param>
    /// <param name="score">得分</param>
    public void SetRankInfo(string rankID, string score)
    {
        this.rankID.text = rankID;
        this.score.text = score;
    }

    /// <summary>
    /// 销毁自身
    /// </summary>
    public void DestroySelf()
    {
        GameObject.Destroy(this.gameObject);
    }
    #endregion
}
