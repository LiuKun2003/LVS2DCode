using LK.LVS2D.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D.Controller
{
    public class TestController : ControllerBase
    {
        TestModel model;
        public Action<int> UpdateView;
        public override void Init()
        {
            model = GetModel<TestModel>();
            model.ValueChange += (m) => UpdateView?.Invoke(m.Score);
        }
        public void Dec()
        {
            model.Dec();
        }
        public void Inc()
        {
            model.Inc();
        }
        public int GetScore()
        {
            return model.Score;
        }
    }
}
