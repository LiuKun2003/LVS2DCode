using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D.Model
{
    public class TestModel : ModelBase
    {
        public Action<TestModel> ValueChange;
        public int Score { get; private set; }
        public override void Init()
        {
            Score = 1;
        }
        public void Inc()
        {
            Score++;
            ValueChange?.Invoke(this);
        }

        public void Dec() 
        {
            Score--;
            ValueChange?.Invoke(this);
        }
    }
}
