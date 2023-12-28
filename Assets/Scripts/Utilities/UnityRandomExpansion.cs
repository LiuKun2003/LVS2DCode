using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D.Utilities
{
    /// <summary>
    /// 用于拓展一些关于Unity中的随机函数的静态类
    /// </summary>
    public static class UnityRandomExpansion
    {
        /// <summary>
        /// 生成一个在指定的范围中的随机二维点，Z值永远为0；
        /// </summary>
        public static Vector3 RandomPoint(this Rect rect)
        {
            Vector3 res = new Vector3
            {
                x = Random.Range(rect.xMin, rect.xMax),
                y = Random.Range(rect.yMin, rect.yMax),
                z = 0
            };
            return res;
        }
    }
}
