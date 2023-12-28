using LK.LVS2D;
using LK.LVS2D.Controller;
using LK.LVS2D.Tools;
using LK.LVS2D.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : ViewBase
{
    private WeaponController weaponController;

    void Start()
    {
        weaponController = GetController<WeaponController>();

        weaponController.AddWeaponToPlayer(Define.From<WeaponDefine>().Get<WeaponInfo>((int)WeaponType.Pistol), 1);
    }
}
