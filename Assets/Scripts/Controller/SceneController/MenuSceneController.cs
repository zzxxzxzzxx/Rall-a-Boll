using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 游戏菜单控制器
/// </summary>
public class MenuSceneController : MonoBehaviour
{
    #region 游戏流程
    void Start ()
    {
        GameFacade.Instance.InitUI();
        GameFacade.Instance.LoadPanel(UIPanelType.Menu); //加载菜单面板
    }
    #endregion
}
