using LK.LVS2D.Controller;
using LK.LVS2D.Model;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

namespace LK.LVS2D.View
{
    public class PlayerView : ViewBase
    {
        public float moveSpeed;

        private PlayerController playerController;
        private WeaponController weaponController;

        private void Start()
        {
            playerController = GetController<PlayerController>();
            weaponController = GetController<WeaponController>();
        }

        private void Update()
        {
            Vector3 vector = new Vector3 
            { 
                x = Input.GetAxisRaw("Horizontal"), 
                y = Input.GetAxisRaw("Vertical") 
            };
            playerController.Move(vector * moveSpeed * Time.deltaTime);
            playerController.UpdateAnimation();
            weaponController.FindAttackTarget();
        }
    }
}
