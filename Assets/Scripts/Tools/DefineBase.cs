using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D.Tools
{
    public abstract class DefineBase
    {
        public abstract void Init();
        public abstract T Get<T>(int index) where T : class;
        public T GetDefine<T>() where T : DefineBase, new() => Define.From<T>();
        public GameObject PrefabLoad(string path) => Resources.Load<GameObject>(path) ?? throw new System.ArgumentException("The specified path does not have resources.");
    }
}
