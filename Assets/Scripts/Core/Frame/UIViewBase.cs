using LK.LVS2D.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace LK.LVS2D.View
{
    public class UIViewBase : MonoBehaviour
    {

        #region Public or protected methods
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
        #endregion

    }
}
