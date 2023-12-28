using LK.LVS2D.Controller;
using LK.LVS2D.Model;
using LK.LVS2D.Tools;
using LK.LVS2D.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D.View
{
    public class EnemyView : ViewBase
    {
        [Header("Setting")]
        public float generationInterval;
        [Min(0.1f)]
        public float different;

        private EnemyController enemyController;
        private float lastGenerationTime;
        private int wave;

        private void Start()
        {
            enemyController = GetController<EnemyController>();
            lastGenerationTime = 0f;
            wave = 0;
        }

        private void Update()
        {
            if (Time.time - lastGenerationTime >= generationInterval / (wave == 0 ? 1 : wave))
            {
                enemyController.Generate(GetRandomEnemy(), transform);
                lastGenerationTime = Time.time;
            }
            wave = (int)(Time.time / different);
            enemyController.Move(Time.deltaTime);
            enemyController.Attack();
        }

        private EnemyInfo GetRandomEnemy()
        {
            return Define.From<EnemyDefine>().Get<EnemyInfo>(Random.Range(0, 3));
        }
    }
}
