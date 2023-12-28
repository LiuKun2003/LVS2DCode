using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace LK.LVS2D.Model
{
    /// <summary>
    /// 数据模型接口
    /// </summary>
    public abstract class ModelBase
    {

        #region Public or protected methods

        /// <summary>
        /// 初始化数据模型
        /// </summary>
        public abstract void Init();

        #endregion
    }
}
