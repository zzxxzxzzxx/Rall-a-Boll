﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// MessagePanel
/// 菜单面板，继承自BasePanel（面板基类）
/// </summary>
public class MenuPanel : BasePanel
{
    #region 成员变量
    /// <summary>
    /// 开始按钮
    /// </summary>
    [SerializeField]
    private Button startButton;

    /// <summary>
    /// 排行榜按钮
    /// </summary>
    [SerializeField]
    private Button rankButton;

    /// <summary>
    /// 退出按钮
    /// </summary>
    [SerializeField]
    private Button quitButton;
    #endregion

    #region 游戏流程
    void Start ()
    {
        startButton.onClick.AddListener(OnStartClick);
        rankButton.onClick.AddListener(OnRankClick);
        quitButton.onClick.AddListener(OnQuitClick);

    }
    #endregion

    #region UI管理器流程
    /// <summary>
    /// OnEnter
    /// 重写BasePanel中的进入
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
    }

    /// <summary>
    /// OnPause
    /// 重写BasePanel中的暂停
    /// </summary>
    public override void OnPause()
    {
        gameObject.SetActive(true);
        base.OnPause();
        startButton.enabled = false;
        rankButton.enabled = false;
        quitButton.enabled = false;
    }

    /// <summary>
    /// OnResume
    /// 重写BasePanel中的恢复
    /// </summary>
    public override void OnResume()
    {
        gameObject.SetActive(true);
        base.OnResume();
        startButton.enabled = true;
        rankButton.enabled = true;
        quitButton.enabled = true;
    }

    /// <summary>
    /// OnExit
    /// 重写BasePanel中的退出
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        uiMng.PopPanel();
        gameObject.SetActive(false);
    }
    #endregion

    #region 私有方法
    /// <summary>
    /// 开始按钮监听
    /// </summary>
    private void OnStartClick()
    {
        facade.LoadToGame();
    }

    /// <summary>
    /// 排行按钮监听
    /// </summary>
    private void OnRankClick()
    {
        uiMng.PushPanel(UIPanelType.Rank);
    }

    /// <summary>
    /// 关闭按钮监听
    /// </summary>
    private void OnQuitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
    #endregion
}
