using LK.LVS2D.Controller;
using LK.LVS2D.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace LK.LVS2D.View
{
    public class ViewBase : MonoBehaviour
    {
        #region Public or protected methods
        protected T GetController<T>() where T : ControllerBase, new()
        {
            T res = ControllerSingleton.Instance.GetController<T>();

            #if UNITY_ASSERTIONS
            Assert.IsNotNull(res);
            #endif

            return res;
        }
        #endregion
    }
}
