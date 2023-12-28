using LK.LVS2D.Controller;
using LK.LVS2D.View;
using LK.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace LK.LVS2D.Model
{
    public class Enemy
    {
        public GameObject GameObject { get; private set; }
        public Vector3 Position => this.GameObject.transform.position;
        public EnemyType Type { get; private set; }
        public int Attack { get; set; } 
        public Limited<int> HeathPoint { get; private set; }
        public float Size { get; set; }
        public float Speed { get; set; }
        public Circle Collision => new Circle(GameObject.transform.position, Size);
        public Enemy(GameObject gameObject, EnemyType enemyType, int attack,int heathPoint, float size, float speed)
        {
#if UNITY_ASSERTIONS
            Assert.IsNotNull(gameObject);
#endif
            this.GameObject = gameObject;
            this.Type = enemyType;
            this.Attack = attack;
            this.HeathPoint = Limited<int>.CreateLowerLimitValue(heathPoint, 0);
            this.Size = size;
            Speed = speed;
        }
        public Enemy(EnemyInfo info)
        {
            this.GameObject = GameObject.Instantiate(info.Prefab);
            this.Type = info.Type;
            this.Attack = info.Attack;
            this.HeathPoint = Limited<int>.CreateLowerLimitValue(info.HeathPoint, 0);
            this.Size = info.Size;
            this.Speed = info.Speed;
        }
        public void Destory()
        {
            GameObject.Destroy(this.GameObject);
            this.GameObject = null;
            this.HeathPoint = null;
        }
    }
    public class EnemyModel : ModelBase
    {
        public LinkedList<Enemy> Enemys { get; private set; }
        public override void Init()
        {
            Enemys = new LinkedList<Enemy>();
        }
        public void DestoryEnemy(LinkedListNode<Enemy> node)
        {
            Enemy enemy = node.Value;
            enemy.Destory();
            Enemys.Remove(node);
        }
    }
}
