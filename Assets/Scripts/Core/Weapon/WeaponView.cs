using LK.LVS2D.Controller;
using LK.LVS2D.Tools;
using LK.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LK.LVS2D.View
{
    public class WeaponView : ViewBase
    {
        public float GetWeaponInterval;

        private WeaponController weaponController;

        private EventProperty<bool> canGetWeapon;

        private Image display;
        private Button button;

        private float lastTime;

        private void Start()
        {
            weaponController = GetController<WeaponController>();

            display = GetComponent<Image>();
            button = GetComponent<Button>();

            canGetWeapon = new EventProperty<bool>(true);
            canGetWeapon.Register(ChangeColor);
            canGetWeapon.Value = false;

            lastTime = 0f;
        }

        private void Update()
        {
            if(Time.time - lastTime >= GetWeaponInterval)
            {
                lastTime = Time.time;
                canGetWeapon.Value = true;
                GetWeaponInterval += 2f;
            }

            if(Input.GetKeyDown(KeyCode.Y))
            {
                AddWeapon();
            }

        }

        public void AddWeapon()
        {
            if(canGetWeapon.Value)
            {
                weaponController.AddWeaponToPlayer(GetRandomWeapon());
                canGetWeapon.Value = false;
            }
        }

        private WeaponInfo GetRandomWeapon()
        {
            return Define.From<WeaponDefine>().Get<WeaponInfo>(Random.Range(0, 6));
        }

        private void ChangeColor(bool b)
        {
            if(b)
            {
                display.color = Color.white;
                button.interactable = true;
            }
            else
            {
                display.color = Color.gray;
                button.interactable = false;
            }
        }
    }
}
