using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D
{
    public class BulletInfo
    {
        public GameObject Prefab { get; private set; }
        public BulletType Type { get; private set; }
        public float Speed { get; private set; }
        public float Size { get; private set; }
        public BulletInfo(GameObject prefab, BulletType bulletType, float flySpeed, float size)
        {
            this.Prefab = prefab;
            this.Type = bulletType;
            this.Speed = flySpeed;
            this.Size = size;
        }
    }
}
