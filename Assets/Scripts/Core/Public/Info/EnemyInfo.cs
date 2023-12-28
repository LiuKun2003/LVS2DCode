using LK.LVS2D.Controller;
using LK.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D
{
    public class EnemyInfo
    {
        public GameObject Prefab { get; private set; }
        public EnemyType Type { get; private set; }
        public int Attack { get; set; }
        public int HeathPoint { get; private set; }
        public float Size { get; set; }
        public float Speed { get; set; }
        
        public EnemyInfo(GameObject prefab, EnemyType type, int attack, int healthPoint, float size, float speed) 
        {
            this.Prefab = prefab;
            this.Type = type;
            this.Attack = attack;
            this.HeathPoint = healthPoint;
            this.Size = size;
            this.Speed = speed;
        }
    }
}
