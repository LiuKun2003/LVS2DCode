using LK.LVS2D.Model;
using LK.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace LK.LVS2D.Controller
{
    public class BulletController : ControllerBase
    {
        private PlayerModel playerModel;
        private MapModel mapModel;
        private EnemyModel enemyModel;
        private LinkedList<Bullet> bullets;
        public override void Init()
        {
            playerModel = GetModel<PlayerModel>();
            enemyModel = GetModel<EnemyModel>();
            mapModel = GetModel<MapModel>();
            bullets = new LinkedList<Bullet>();
        }

        public void TryShooting(Transform father)
        {
            foreach (var weapon in playerModel.GetWeapons())
            {
                if (weapon != null && weapon.AttackTarget != null && Time.time - weapon.LastShootingTime >= weapon.AttackInterval / playerModel.AttackSpeed)
                {
                    weapon.LastShootingTime = Time.time;
                    switch (weapon.BulletInfo.Type)
                    {
                        case BulletType.Normal:
                        case BulletType.Small:
                        case BulletType.Big:
                            {
                                Bullet blt = new Bullet(weapon.BulletInfo, (weapon.AttackTarget.position - weapon.Position).normalized, weapon.Attack);
                                Transform tf = blt.GameObject.transform;
                                tf.SetParent(father);
                                tf.position = weapon.Position;
                                bullets.AddLast(blt);
                            }
                            break;
                        case BulletType.Shot:
                            {
                                Vector3 dir = (weapon.AttackTarget.position - weapon.Position).normalized;
                                Bullet blt = new Bullet(weapon.BulletInfo, dir, weapon.Attack);
                                Transform tf = blt.GameObject.transform;
                                tf.SetParent(father);
                                tf.position = weapon.Position;
                                Bullet blt2 = new Bullet(weapon.BulletInfo, Rotate(dir, 15f).normalized, weapon.Attack);
                                tf = blt2.GameObject.transform;
                                tf.SetParent(father);
                                tf.position = weapon.Position;
                                Bullet blt3 = new Bullet(weapon.BulletInfo, Rotate(dir, -15f).normalized, weapon.Attack);
                                tf = blt3.GameObject.transform;
                                tf.SetParent(father);
                                tf.position = weapon.Position;
                                bullets.AddLast(blt);
                                bullets.AddLast(blt2);
                                bullets.AddLast(blt3);
                            }
                            break;
                    }
                }
            }
        }

        public void Move(float weight)
        {
            for (var it = bullets.First; it != null;)
            {
                var next = it.Next;
                Bullet bullet = it.Value;
                switch (bullet.Type)
                {
                    case BulletType.Small:
                    case BulletType.Big:
                    case BulletType.Normal:
                    case BulletType.Shot:
                        {
                            Transform go = bullet.GameObject.transform;
                            if (Attack(bullet) || !mapModel.MapLimit.Contains((Vector2)bullet.Position))
                            {
                                bullet.Destory();
                                bullets.Remove(it);
                                it.Value = null;
                            }
                            else
                            {
                                go.transform.position += bullet.Direction * bullet.Speed * weight;
                            }
                        }
                        break;
                }
                it = next;
            }
        }
        
        private bool Attack(Bullet bullet)
        {
            for (var it = enemyModel.Enemys.First; it != null;)
            {
                Enemy enemy = it.Value;
                var next = it.Next;
                if(enemy.Collision.Overlaps(bullet.Collision))
                {
                    enemy.HeathPoint.Value -= bullet.Attack;
                    if(enemy.HeathPoint.Value <= 0)
                    {
                        enemyModel.DestoryEnemy(it);
                        playerModel.Score.Value += 1;
                    }
                    return true;
                }
                it = next;
            }
            return false;
        }

        private Vector2 Rotate(Vector2 vector, float angle)
        {
            float rad = Mathf.Deg2Rad * angle;
            float cos = Mathf.Cos(rad);
            float sin = Mathf.Sin(rad);
            return new Vector2{ x = vector.x * cos - vector.y * sin, y = vector.y * cos - vector.x * sin};
        }
    }
}
