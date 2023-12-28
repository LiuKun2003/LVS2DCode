using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D.Tools
{
    public class EnemyDefine : DefineBase
    {
        private List<EnemyInfo> enemyInfos;

        public override void Init()
        {
            enemyInfos = new List<EnemyInfo>()
            {
                new EnemyInfo(PrefabLoad(GamePath.EnemyPrefabsPath + "Chase"), EnemyType.Chase, 1, 10, 0.7f, 3f),
                new EnemyInfo(PrefabLoad(GamePath.EnemyPrefabsPath + "IMP"), EnemyType.IMP, 1, 4, 0.35f, 6f),
                new EnemyInfo(PrefabLoad(GamePath.EnemyPrefabsPath + "Kong"), EnemyType.Kong, 1, 30, 1.4f, 1.5f),
            };
        }

        public override T Get<T>(int index) => enemyInfos[index] as T;
    }
}
