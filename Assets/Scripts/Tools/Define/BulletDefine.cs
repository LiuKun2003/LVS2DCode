using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace LK.LVS2D.Tools
{
    public class BulletDefine : DefineBase
    {
        private List<BulletInfo> bulletInfos;

        public override void Init()
        {
            bulletInfos = new List<BulletInfo>()
            {
                new BulletInfo(PrefabLoad(GamePath.BulletsPrefabsPath + "Normal"), BulletType.Normal, 5f, 0.0875f),
                new BulletInfo(PrefabLoad(GamePath.BulletsPrefabsPath + "Small"), BulletType.Small, 8f, 0.04375f),
                new BulletInfo(PrefabLoad(GamePath.BulletsPrefabsPath + "Big"), BulletType.Big, 3.5f, 0.21875f),
                new BulletInfo(PrefabLoad(GamePath.BulletsPrefabsPath + "Normal"), BulletType.Shot, 4f, 0.0875f),
            };
        }

        public override T Get<T>(int index) => bulletInfos[index] as T;
    }
}
