using LK.LVS2D.Model;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Assertions;

namespace LK.LVS2D.Controller
{
    public class WeaponController : ControllerBase
    {
        private PlayerModel playerModel;
        private EnemyModel enemyModel;
        public override void Init()
        {
            playerModel = GetModel<PlayerModel>();
            enemyModel = GetModel<EnemyModel>();
        }

        public void AddWeaponToPlayer(WeaponInfo weaponInfo, int index)
        {
            Weapon weapon = new Weapon(weaponInfo);
            Transform tf = weapon.GameObject.transform;
            tf.SetParent(playerModel.Player.transform);
            tf.localPosition = GetPosition(index);
            playerModel.AddWeapon(weapon, index);

        }

        public void AddWeaponToPlayer(WeaponInfo weaponInfo)
        {
            int index;
            if(playerModel.WeaponsCount == playerModel.WeaponLimit)
            {
                index = Random.Range(0, playerModel.WeaponsCount);
                index++;
            }
            else
            {
                index = 1;
                foreach (var wp in playerModel.GetWeapons())
                {
                    if (wp is null) break;
                    else index++;
                } 
            }
            Weapon weapon = new Weapon(weaponInfo);
            Transform tf = weapon.GameObject.transform;
            tf.SetParent(playerModel.Player.transform);
            tf.localPosition = GetPosition(index);
            playerModel.ReplaceWeapon(weapon, index);
        }

        public void RemoveWeaponFromPlayer() 
        {
            throw new System.NotImplementedException();
        }

        public void FindAttackTarget()
        {
            foreach (var weapon in playerModel.GetWeapons())
            {
                if (weapon != null)
                {
                    float min = float.MaxValue;
                    bool mark = true;
                    foreach (var enemy in enemyModel.Enemys)
                    {
                        float dis = Vector3.Distance(weapon.Position, enemy.Position);
                        if (dis <= weapon.AttackDistance && dis < min)
                        {
                            min = dis;
                            mark = false;
                            weapon.AttackTarget = enemy.GameObject.transform;
                        }
                    }
                    if (mark) weapon.AttackTarget = null;
                }
            }
        }

        private Vector3 GetPosition(int index)
        {
            float angle = 360f / playerModel.WeaponLimit * (index - 1) * Mathf.Deg2Rad;
            return new Vector3(playerModel.HoldWeaponDistance * Mathf.Sin(angle), playerModel.HoldWeaponDistance * Mathf.Cos(angle), 0f);
        }
    }
}
