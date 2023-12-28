using LK.LVS2D.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D.View
{
    public class BulletView : ViewBase
    {
        BulletController bulletController;
        private void Start()
        {
            bulletController = GetController<BulletController>();
        }

        private void LateUpdate()
        {
            bulletController.TryShooting(transform);
            bulletController.Move(Time.deltaTime);
        }
    }
}
