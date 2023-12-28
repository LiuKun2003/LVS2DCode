using LK.LVS2D.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LK.LVS2D.View
{
    public class TestView : ViewBase
    {
        TestController controller;
        public Button incButton;
        public Button decButton;
        public Text numberText;
        
        private void Start()
        {
            controller = GetController<TestController>();
            controller.UpdateView += (a) => numberText.text = a.ToString();
            numberText.text = controller.GetScore().ToString();
            incButton.onClick.AddListener(() => controller.Inc());
            decButton.onClick.AddListener(() => controller.Dec());
        }
    }
}
