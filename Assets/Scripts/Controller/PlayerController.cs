using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 玩家控制器
/// 处理玩家移动和得分显示
/// </summary>
public class PlayerController : MonoBehaviour
{
    #region 成员变量
    /// <summary>
    /// 移动速度
    /// </summary>
    [SerializeField]
    private float speed;

    /// <summary>
    /// 游戏物体的刚体组件
    /// </summary>
    private Rigidbody rb;

    /// <summary>
    /// 游戏控制器
    /// </summary>
    [SerializeField]
    private GameController gameController;
    #endregion

    #region 游戏流程
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameFacade.Instance.LoadPanel(UIPanelType.Message);
    }

    void FixedUpdate()
    {
        if (GameFacade.Instance.currentGameState.Equals(GameStateType.Gaming))
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

            rb.AddForce(movement * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameFacade.Instance.currentGameState.Equals(GameStateType.Gaming) &&
            other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            gameController.AddScore();
        }
    }
    #endregion
}
