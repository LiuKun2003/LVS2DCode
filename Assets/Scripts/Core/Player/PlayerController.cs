using LK.LVS2D.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace LK.LVS2D.Controller
{
    public class PlayerController : ControllerBase
    {
        private PlayerModel playerModel;
        private MapModel mapModel;
        private EnemyModel enemyModel;

        public override void Init()
        {
            playerModel = GetModel<PlayerModel>();
            mapModel = GetModel<MapModel>();
            enemyModel = GetModel<EnemyModel>();        
        }

        public void Move(Vector3 translation)
        {
            Vector3 pos = playerModel.Position;
            pos += translation;

            if(mapModel.MapLimit.Contains((Vector2)pos))
            {
                playerModel.Player.transform.position = pos;
            }
        }

        public void UpdateAnimation()
        {
            playerModel.Animator.SetBool("IsInvulnerability", playerModel.IsInvulnerability);
        }
    }
}
