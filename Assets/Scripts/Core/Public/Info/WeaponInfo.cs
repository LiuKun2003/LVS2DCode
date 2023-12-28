using LK.LVS2D.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D
{
    public class WeaponInfo
    {
        public GameObject Prafab { get; private set; }
        public BulletInfo BulletInfo { get; set; }
        public int Attack { get; private set; }
        public float AttackInterval { get; private set; }
        public float AttackDistance { get; private set; }
        public WeaponInfo(GameObject prafab, BulletInfo bulletInfo, int attack, float attackInterval, float attackDistance)
        {
            this.Prafab = prafab;
            this.BulletInfo = bulletInfo;
            this.Attack = attack;
            this.AttackInterval = attackInterval;
            this.AttackDistance = attackDistance;
        }
    }
}
