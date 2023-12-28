using LK.LVS2D.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LK.LVS2D.View
{
    public class UIHealthBar : UIViewBase
    {
        public Slider Slider;
        public GameObject GameOverObject;

        private PlayerModel playerModel;
        private void Start()
        {

            playerModel = GetModel<PlayerModel>();

            GameOverObject.SetActive(false);

            UpdateHealthBar((float)playerModel.HealthPoint.Value / playerModel.HealthPointLimit);
            playerModel.HealthPoint.Register((health) => 
            {
                UpdateHealthBar((float)health / playerModel.HealthPointLimit);
            });
        }

        public void UpdateHealthBar(float value)
        {
            Slider.value = value;

            if(value <= 0)
            {
                Time.timeScale = 0f;
                GameOverObject.SetActive(true);
            }
        }
    }
}
