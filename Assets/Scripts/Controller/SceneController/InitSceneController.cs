using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏初始化控制器
/// </summary>
public class InitSceneController : MonoBehaviour
{
    #region 游戏流程
    void Start()
    {
        GameFacade.Instance.InitUI();
        StartCoroutine(LoadMenu());
    }
    #endregion

    #region 私有方法
    //延时加载菜单场景
    private IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(2f);
        GameFacade.Instance.LoadToMenu();
        //SceneManager.LoadMenu();
    }
    #endregion
}
