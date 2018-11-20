using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 摄像机控制器
/// 随玩家移动而移动
/// </summary>
public class CameraController : MonoBehaviour
{
    #region 成员变量
    /// <summary>
    /// 摄像机跟随的对象
    /// </summary>
    [SerializeField]
    public GameObject player;

    /// <summary>
    /// 摄像机和跟随对象之间的距离
    /// </summary>
    private Vector3 offset;
    #endregion

    #region 游戏流程
    void Start ()
    {
        offset = transform.position - player.transform.position;	
	}
	
	void LateUpdate ()
    {
        transform.position = player.transform.position + offset;
	}
    #endregion
}
