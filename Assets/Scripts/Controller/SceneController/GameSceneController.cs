using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏场景控制器
/// </summary>
public class GameSceneController : MonoBehaviour
{
    #region 游戏流程
    void Start()
    {
        GameFacade.Instance.InitUI();
    }
    #endregion
}
