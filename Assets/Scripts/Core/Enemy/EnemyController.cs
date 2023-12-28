using LK.LVS2D.Model;
using LK.LVS2D.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace LK.LVS2D.Controller
{
    public class EnemyController : ControllerBase
    {
        private MapModel mapModel;
        private PlayerModel playerModel;
        private EnemyModel enemyModel;
        private LinkedList<Enemy> enemys;
        public override void Init()
        {
            mapModel = GetModel<MapModel>();
            playerModel = GetModel<PlayerModel>();
            enemyModel = GetModel<EnemyModel>();

            enemys = enemyModel.Enemys;
        }

        public void Generate(EnemyInfo info, Transform father)
        {
            Vector3 pos = mapModel.MapLimit.RandomPoint();
            Enemy enemy = new Enemy(info);
            Transform tf = enemy.GameObject.transform;
            tf.SetParent(father);
            tf.position = pos;
            enemys.AddLast(enemy);
        }

        public void Move(float weight)
        {
            foreach (var enemy in enemys)
            {
                GameObject go = enemy.GameObject;
                Vector3 pos = go.transform.position, playerPos = playerModel.Player.transform.position;
                if (Vector3.Distance(pos, playerPos) > 0.02f)
                {
                    pos += (playerPos - pos).normalized * enemy.Speed * weight;
                    if (mapModel.MapLimit.Contains((Vector2)pos))
                    {
                        go.transform.position = pos;
                    }
                }
            }
        }

        public void Attack()
        {
            if (!playerModel.IsInvulnerability)
            {
                foreach (var enemy in enemys)
                {
                    if (enemy.Collision.Overlaps(playerModel.Collision))
                    {
                        playerModel.Damage(enemy.Attack);
                        break;
                    }
                }
            }
        }
   
    }
}
