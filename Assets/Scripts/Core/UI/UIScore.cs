using LK.LVS2D.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LK.LVS2D.View
{
    public class UIScore : UIViewBase
    {
        public Text text;

        private PlayerModel playerModel;

        private void Start()
        {

            playerModel = GetModel<PlayerModel>();

            UpdateScore(playerModel.Score.Value);
            playerModel.Score.Register((score) =>
            {
                UpdateScore(score);
            });
        }

        public void UpdateScore(int score)
        {
            text.text = score.ToString();
        }
    }
}
