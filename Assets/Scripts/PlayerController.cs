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
    /// 显示得分的文本
    /// </summary>
    [SerializeField]
    private Text countText;

    /// <summary>
    /// 胜利提示的文本
    /// </summary>
    [SerializeField]
    private Text winText;

    /// <summary>
    /// 游戏物体的刚体组件
    /// </summary>
    private Rigidbody rb;

    /// <summary>
    /// 记录得分
    /// </summary>
    private int count;
    #endregion

    #region 游戏流程
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
    #endregion

    #region 私有方法
    /// <summary>
    /// 用来更新得分文本和胜利文本
    /// </summary>
    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 6)
        {
            winText.text = "You Win!";
        }
    }
    #endregion
}
