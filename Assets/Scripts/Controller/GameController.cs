using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region 成员变量
    /// <summary>
    /// 显示得分的文本
    /// </summary>
    [SerializeField]
    private Text scoreText;

    /// <summary>
    /// 中途放弃按钮
    /// </summary>
    [SerializeField]
    private Button gameForgiveButton;

    /// <summary>
    /// 游戏放弃按钮
    /// </summary>
    [SerializeField]
    private Button gameOverButton;

    /// <summary>
    /// 记录得分
    /// </summary>
    private int score;

    /// <summary>
    /// 倒计时
    /// </summary>
    private int timeCountDown;
    #endregion

    #region 游戏流程
    private void Start()
    {
        gameForgiveButton.onClick.AddListener(OnForgiveClick);
        gameOverButton.onClick.AddListener(OnGameOverClick);
    }

    private void Update ()
    {
        if (!GameFacade.Instance.gameUIUpdate &&
            GameFacade.Instance.currentGameState.Equals(GameStateType.Start))
        {
            ToGameStart();
        }

        if (!GameFacade.Instance.gameUIUpdate && 
            GameFacade.Instance.currentGameState.Equals(GameStateType.Gaming))
        {
            ToGaming();
        }

        if (!GameFacade.Instance.gameUIUpdate && 
            GameFacade.Instance.currentGameState.Equals(GameStateType.End))
        {
            ToGameOver();
        }
	}
    #endregion

    #region 提供的方法
    /// <summary>
    /// 增加分数
    /// </summary>
    public void AddScore()
    {
        score++;
        SetScoreText();
    }
    #endregion

    #region 私有方法
    /// <summary>
    /// ui切换到游戏开始
    /// </summary>
    private void ToGameStart()
    {
        score = 0; //分数重置
        SetScoreText(); //刷新ui

        timeCountDown = 3; //倒计时设置

        //按钮显示设置
        gameForgiveButton.gameObject.SetActive(false);
        gameOverButton.gameObject.SetActive(false);

        GameFacade.Instance.gameUIUpdate = true; //刷新标记更新

        StartCoroutine(TimeCountDown()); //倒计时协程
    }

    /// <summary>
    /// ui切换到游戏中
    /// </summary>
    private void ToGaming()
    {
        score = 0; //分数重置
        SetScoreText(); //刷新ui

        //按钮显示设置
        gameForgiveButton.gameObject.SetActive(true);
        gameOverButton.gameObject.SetActive(false);

        GameFacade.Instance.gameUIUpdate = true;//刷新标记更新
    }

    /// <summary>
    /// ui切换到游戏结束
    /// </summary>
    private void ToGameOver()
    {
        GameFacade.Instance.ShowMessage("收集完成~"); //游戏结束提示

        //按钮显示设置
        gameForgiveButton.gameObject.SetActive(false);
        gameOverButton.gameObject.SetActive(true);

        GameFacade.Instance.gameUIUpdate = true;//刷新标记更新
    }

    /// <summary>
    /// 设置显示的分数
    /// </summary>
    private void SetScoreText()
    {
        scoreText.text = score.ToString(); //更新分数

        //游戏结束判断
        if (score >= 6)
        {
            GameFacade.Instance.currentGameState = GameStateType.End;
            GameFacade.Instance.gameUIUpdate = false;
        }
    }

    /// <summary>
    /// 倒计时协程
    /// </summary>
    /// <returns></returns>
    private IEnumerator TimeCountDown()
    {
        for (int timer = timeCountDown; timer > 0; timer--)
        {
            GameFacade.Instance.ShowMessage(timer.ToString()); //倒计时显示
            yield return new WaitForSeconds(2f);
        }

        //更新游戏状态
        GameFacade.Instance.currentGameState = GameStateType.Gaming; 
        GameFacade.Instance.gameUIUpdate = false;
    }

    /// <summary>
    /// 放弃按钮监听
    /// </summary>
    private void OnForgiveClick()
    {
        GameFacade.Instance.InsertRank(score); //更新排名
        GameFacade.Instance.LoadToMenu(); //加载场景
    }

    /// <summary>
    /// 游戏结束监听
    /// </summary>
    private void OnGameOverClick()
    {
        GameFacade.Instance.InsertRank(score); //更新排名
        GameFacade.Instance.LoadToMenu(); //加载场景
    }
    #endregion
}
