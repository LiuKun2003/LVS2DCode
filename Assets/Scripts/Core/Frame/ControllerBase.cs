using LK.LVS2D.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace LK.LVS2D.Controller
{
    public abstract class ControllerBase
    {
        #region Public or protected methods

        /// <summary>
        /// 初始化控制器
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// 获取指定类型的数据模型
        /// </summary>
        protected T GetModel<T>() where T : ModelBase, new()
        {
            T res = ModelSingleton.Instance.GetModel<T>();

            #if UNITY_ASSERTIONS
            Assert.IsNotNull(res);
            #endif

            return res;
        }

//        protected void AddToTrusteeshipUpdate(Action action)
//        {
//#if UNITY_ASSERTIONS
//            Assert.IsNotNull(FrameworkTrusteeship.Instance);
//#endif
//            FrameworkTrusteeship.Instance.OnUpdate += action;
//        }

//        protected void RemoveFromTrusteeshipUpdate(Action action)
//        {
//#if UNITY_ASSERTIONS
//            Assert.IsNotNull(FrameworkTrusteeship.Instance);
//#endif
//            FrameworkTrusteeship.Instance.OnUpdate -= action;
//        }
        #endregion
    }
}
