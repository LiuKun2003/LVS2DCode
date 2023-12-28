using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D.Model
{
    public class MapModel : ModelBase
    {
        public Rect MapLimit { get; private set; }
        public override void Init()
        {
            MapLimit = new Rect(new Vector2(-14.25f, -10.75f), new Vector2(28.5f, 21.5f));
        }
    }
}
