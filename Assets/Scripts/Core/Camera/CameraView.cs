using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LK.LVS2D.View
{
    public class CameraView : ViewBase
    {
        public Transform target;
        public float smoothSpeed;
        public float deadZoneDistance;
        //public Vector2 limitZoneMin;
        //public Vector2 limitZoneMax;

        private void LateUpdate()
        {
            if(Vector2.Distance(transform.position, target.position) > deadZoneDistance)
            {
                Vector2 targPos = target.position;
                Vector2 thisPos = transform.position;

                Vector3 pos = Vector2.Lerp(thisPos, targPos, smoothSpeed * Time.deltaTime);
                pos.z = transform.position.z;
                transform.position = pos;
            }
        }

        //private bool OutOfRange()
        //{
        //    float x = transform.position.x, y = transform.position.y;
        //    if (
        //        x > limitZoneMax.x ||
        //        x < limitZoneMin.x ||
        //        y > limitZoneMax.y ||
        //        y < limitZoneMin.y
        //       )
        //        return true;
        //    else
        //        return false;
        //}
    }
}
