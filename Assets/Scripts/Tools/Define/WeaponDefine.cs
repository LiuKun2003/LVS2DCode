using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D.Tools
{
    public class WeaponDefine : DefineBase
    {
        private BulletDefine bulletDefine;

        private List<WeaponInfo> weaponInfos;

        public override void Init()
        {
            bulletDefine = GetDefine<BulletDefine>();
            weaponInfos = new List<WeaponInfo>()
            {
                new WeaponInfo(PrefabLoad(GamePath.WeaponsPrefabsPath + "Pistol"), bulletDefine.Get<BulletInfo>((int)BulletType.Normal), 4, 1f, 6f),
                new WeaponInfo(PrefabLoad(GamePath.WeaponsPrefabsPath + "SMG"), bulletDefine.Get<BulletInfo>((int)BulletType.Small), 2, 0.6f, 6f),
                new WeaponInfo(PrefabLoad(GamePath.WeaponsPrefabsPath + "PSR"), bulletDefine.Get<BulletInfo>((int)BulletType.Small), 24, 5, 12f),
                new WeaponInfo(PrefabLoad(GamePath.WeaponsPrefabsPath + "Cannon"), bulletDefine.Get<BulletInfo>((int)BulletType.Big), 8, 2f, 8f),
                new WeaponInfo(PrefabLoad(GamePath.WeaponsPrefabsPath + "Gatling"), bulletDefine.Get<BulletInfo>((int)BulletType.Small), 1, 0.3f, 6f),
                new WeaponInfo(PrefabLoad(GamePath.WeaponsPrefabsPath + "Shotgun"), bulletDefine.Get<BulletInfo>((int)BulletType.Shot), 2, 1f, 4.5f),
            };
        }

        public override T Get<T>(int index) => weaponInfos[index] as T;
    }
}
