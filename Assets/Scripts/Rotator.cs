using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制自身不停旋转
/// </summary>
public class Rotator : MonoBehaviour
{
    #region 游戏流程
    void Update ()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);	
	}
    #endregion
}
