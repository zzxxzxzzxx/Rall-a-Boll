using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Common;

/// <summary>
/// GameFacade
/// 游戏中介者管理，继承自MonoBehaviour（可挂载到游戏物体上）
/// 将facade类做成单例模式
/// 将各个插件用facade类统一管理起来
/// </summary>
public class GameFacade : MonoBehaviour
{

    #region 成员变量
    /// <summary>
    /// GameFacade类单例_instance
    /// </summary>
    private static GameFacade _instance;

    /// <summary>
    /// 建立GameFacade类单例
    /// </summary>
    public static GameFacade Instance
    {
        //共有get方法，若本身不存在则建立单例（获取游戏物体GameFacade中的GameFacade脚本），否则返回本身
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("GameFacade").GetComponent<GameFacade>();
            }
            return _instance;
        }

        //私有set方法，让属性无法从外界赋值
        private set
        {
        }
    }

    /// <summary>
    /// 当前场景类型
    /// </summary>
    public SceneType currentSceneType;

    /// <summary>
    /// 当前游戏状态
    /// </summary>
    public GameStateType currentGameState;

    /// <summary>
    /// 游戏UI更新标记
    /// </summary>
    public bool gameUIUpdate;

    /// <summary>
    /// 场景管理器
    /// </summary>
    private SceneManager sceneMng;

    /// <summary>
    /// UI管理器
    /// </summary>
    private UIManager uiMng;

    /// <summary>
    /// 排名管理器
    /// </summary>
    private RankManager rankMng;
    #endregion

    #region 游戏流程
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //初始化游戏状态
        currentGameState = GameStateType.None;
        currentSceneType = SceneType.None;

        InitManager(); //初始化管理器
    }

    private void OnDestroy()
    {
        DestroyManager(); //销毁所有管理器
    }
    #endregion

    #region 场景管理器的方法
    /// <summary>
    /// 加载菜单场景
    /// </summary>
    public void LoadToMenu()
    {
        sceneMng.LoadToMenu();
        currentGameState =  GameStateType.None;
    }

    /// <summary>
    /// 加载游戏场景
    /// </summary>
    public void LoadToGame()
    {
        sceneMng.LoadToGame();
        currentGameState = GameStateType.Start;
        gameUIUpdate = false;
    }
    #endregion

    #region UI管理器的方法
    /// <summary>
    /// 调用UI管理器中的ShowMessage
    /// </summary>
    /// <param name="msg">显示的内容</param>
    public void ShowMessage(string msg)
    {
        uiMng.ShowMessage(msg);
    }

    /// <summary>
    /// 初始化UI
    /// </summary>
    public void InitUI()
    {
        if (uiMng != null) uiMng.OnInit();
    }

    /// <summary>
    /// 加载UI面板
    /// </summary>
    /// <param name="type"></param>
    public void LoadPanel(UIPanelType type)
    {
        uiMng.PushPanel(type);
    }
    #endregion

    #region 排名管理器的方法
    /// <summary>
    /// 添加排名
    /// </summary>
    /// <param name="score">添加的分数</param>
    public void InsertRank(int score)
    {
        rankMng.InsertRank(score);
    }

    /// <summary>
    /// 获取排名
    /// </summary>
    /// <returns>排名数组</returns>
    public int[] GetRank()
    {
        return rankMng.Rank;
    }
    #endregion

    #region 私有方法
    /// <summary>
    /// InitManager
    /// 初始化管理器
    /// </summary>
    private void InitManager()
    {
        //创建所有需要的管理器，把facade中介传递过去
        sceneMng = new SceneManager(this);
        uiMng = new UIManager(this);
        rankMng = new RankManager(this);

        //运行各自管理器的初始化
        sceneMng.OnInit();
        uiMng.OnInit();
        rankMng.OnInit();
    }

    /// <summary>
    /// DestroyManager
    /// 销毁所有管理器
    /// </summary>
    private void DestroyManager()
    {
        //调用各个管理器的Destroy
        sceneMng.OnDestroy();
        uiMng.OnDestroy();
        rankMng.OnDestroy();
    }
    #endregion
}
