using LK.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D.Model
{
    public class Weapon
    {
        public GameObject GameObject { get; private set; }
        public BulletInfo BulletInfo { get; set; }
        public int Attack { get; private set; }
        public Transform AttackTarget { get; set; }
        public float AttackInterval { get; private set; }
        public float AttackDistance { get; private set; }
        public float LastShootingTime { get; set; }
        public Circle AttackRange => new Circle(GameObject.transform.position, AttackDistance);
        public Vector3 Position => GameObject.transform.position;

        public Weapon(WeaponInfo info)
        {
            this.GameObject = GameObject.Instantiate(info.Prafab);
            this.AttackTarget = null;
            this.Attack = info.Attack;
            this.AttackInterval = info.AttackInterval;
            this.AttackDistance = info.AttackDistance;
            this.BulletInfo = info.BulletInfo;
            this.LastShootingTime = Time.time;
        }

        public void Destory()
        {
            GameObject.Destroy(this.GameObject);
            GameObject = null;
            BulletInfo = null;
        }
    }
}
