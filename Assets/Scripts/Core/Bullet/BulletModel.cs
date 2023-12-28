using LK.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D.Model
{
    public class Bullet
    {
        public GameObject GameObject { get; private set; }
        public Vector3 Position => this.GameObject.transform.position;
        public BulletType Type { get; private set; }
        public Vector3 Direction { get; private set; }
        public float Speed { get; private set; }
        public float Size { get; private set; }
        public int Attack { get; private set; }
        public Circle Collision => new Circle(this.GameObject.transform.position, Size);

        public Bullet(BulletInfo info, Vector3 direction, int attack)
        {
            this.GameObject = GameObject.Instantiate(info.Prefab);
            this.Type = info.Type;
            this.Speed = info.Speed;
            this.Size = info.Size;
            this.Direction = direction;
            this.Attack = attack;
        }

        public void Destory()
        {
            GameObject.Destroy(this.GameObject);
            GameObject = null;
        }
    }
}