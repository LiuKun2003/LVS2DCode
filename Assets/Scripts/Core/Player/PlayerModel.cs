using LK.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Assertions;

namespace LK.LVS2D.Model
{
    public class PlayerModel : ModelBase
    {
        private float m_AttackDistance;
        public GameObject Player { get; private set; }
        public Vector3 Position => Player.transform.position;
        public float Size { get; private set; }
        public Circle Collision => Player is null ? Circle.zero : new Circle(Player.transform.position, Size);
        public Animator Animator { get; private set; }
        public EventProperty<int> HealthPoint { get; private set; }
        public int HealthPointLimit { get; private set; }
        public float InvulnerabilityTime { get; private set; }
        public float InvulnerabilityIncrement { get; private set; }
        public bool IsInvulnerability => Time.time <= InvulnerabilityTime;
        private List<Weapon> Weapons { get; set; }
        public int WeaponsCount { get; private set; }
        public ushort WeaponLimit { get; private set; }
        public float HoldWeaponDistance { get; private set; }
        public float AttackSpeed { get; private set; }
        public EventProperty<int> Score { get; private set; }

        public override void Init()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            Animator = Player.GetComponent<Animator>();
#if UNITY_ASSERTIONS
            Assert.IsNotNull(Player);
            Assert.IsNotNull(Animator);
#endif
            Size = 0.7f;
            HealthPoint = new EventProperty<int>(10);
            HealthPointLimit = 10;
            InvulnerabilityTime = 0f;
            InvulnerabilityIncrement = 2f;
            WeaponLimit = 6;
            HoldWeaponDistance = 0.12f;
            Score = new EventProperty<int>(0);
            Weapons = new List<Weapon>(WeaponLimit){};
            for(int i = 0; i < WeaponLimit; i++)
            {
                Weapons.Add(null);
            }
            AttackSpeed = 1f;
        }
        public void Damage(int damage)
        {
            if (!IsInvulnerability)
            {
                HealthPoint.Value -= damage;
                if (HealthPoint.Value < 0) HealthPoint.Value = 0;
                InvulnerabilityTime = Time.time + InvulnerabilityIncrement;
            }
        }
        public void Damage(float damage)
        {
            int _damage = Mathf.RoundToInt(damage);
            if (!IsInvulnerability)
            {
                HealthPoint.Value -= _damage;
                if (HealthPoint.Value < 0) HealthPoint.Value = 0;
                InvulnerabilityTime = Time.time + InvulnerabilityIncrement;
            }
        }
        public IEnumerable<Weapon> GetWeapons() 
        {
            return Weapons;
        }
        public void AddWeapon(Weapon weapon, int index)
        {
            index--;
            if (weapon is null)
            {
                throw new ArgumentNullException(nameof(weapon));
            }
            else if(index >= WeaponLimit || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            else if(Weapons[index] != null)
            {
                throw new ArgumentException("A weapon already exists at the specified index.");
            }
            else
            {
                Weapons[index] = weapon;
                WeaponsCount++;
            }
        }
        public void ReplaceWeapon(Weapon weapon, int index)
        {
            index--;
            if (index >= WeaponLimit || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if (Weapons[index] != null)
            {
                Weapons[index].Destory();
                Weapons[index] = null;
            }
            else
            {
                WeaponsCount++;
            }
            Weapons[index] = weapon;
        }
        public bool RemoceWeapon(int index)
        {
            index--;
            if(index >= WeaponLimit || index < 0)
            {
                return false;
            }
            else
            {
                Weapons[index - 1] = null;
                WeaponsCount--;
                return true;
            }
        }
    }
}
