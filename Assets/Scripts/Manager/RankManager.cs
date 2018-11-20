using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankManager : BaseManager
{
    #region 构造方法
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="facade">中介者</param>
    public RankManager(GameFacade facade) : base(facade) { }
    #endregion

    #region 成员变量
    /// <summary>
    /// 要存储排名的数量
    /// </summary>
    public int rankNumber;

    /// <summary>
    /// 存储排名的数组属性
    /// </summary>
    public int[] Rank
    {
        get;
        private set;
    }
    #endregion

    #region 提供的方法
    /// <summary>
    /// 重写基类的初始化方法
    /// </summary>
    public override void OnInit()
    {
        base.OnInit();
        rankNumber = 10; //设定排名数量
        GetRank(); //获取原来的排名
    }

    /// <summary>
    /// 添加新分数到排名数组中
    /// </summary>
    /// <param name="score">新的分数</param>
    public void InsertRank(int score)
    {
        bool insertComplete = false;
        for (int rankID = rankNumber; rankID > 1; rankID--)
        {
            if (score > Rank[rankID])
            {
                Rank[rankID] = Rank[rankID - 1];
            }
            else
            {
                insertComplete = true;
                if (rankID == rankNumber) break;
                Rank[rankID + 1] = score;
            }
        }
        if (!insertComplete)
        {
            if (Rank[1] < score)
                Rank[1] = score;
            else
                Rank[2] = score;
        }

        SetRank();
    }
    #endregion

    #region 私有方法
    /// <summary>
    /// 获取PlayerPrefs中的排名
    /// </summary>
    private void GetRank()
    {
        Rank = new int[rankNumber + 1];
        for (int rankID = 1; rankID <= rankNumber; rankID++)
        {
            string rankKey = "Rank" + rankID.ToString();
            Rank[rankID] = PlayerPrefs.GetInt(rankKey, -1);
        }
    }

    /// <summary>
    /// 存储现在的排名
    /// </summary>
    private void SetRank()
    {
        for (int rankID = 1; rankID <= rankNumber; rankID++)
        {
            if (Rank[rankID] == -1) break;
            string rankKey = "Rank" + rankID.ToString();
            PlayerPrefs.SetInt(rankKey, Rank[rankID]);
        }
    }
    #endregion
}
