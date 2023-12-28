using LK.LVS2D.Controller;
using LK.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D.Tools
{
    public static class Define
    {
        private static Dictionary<Type, DefineBase> m_Dictionary = new Dictionary<Type, DefineBase>();
        private static PathLock<Type> m_PathLock = new PathLock<Type>();
        public static T From<T>() where T : DefineBase, new()
        {
            Type type = typeof(T);
            if (m_Dictionary.ContainsKey(type))
            {
                return m_Dictionary[type] as T;
            }
            else
            {
                T res = new T();
                m_PathLock.Lock(type);
                res.Init();
                m_PathLock.ReleaseAll();
                m_Dictionary.Add(type, res);
                return res;
            }
        }
    }

}
