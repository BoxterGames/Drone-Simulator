using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sensors.Input
{
    public class Lidar : InputSensor
    {
        public float Distance { get; private set; }
    
        public override void FillSensorsData(ref SensorsData data)
        {
            data.Height = Distance;
        }

        private void Update()
        {
            Physics.Raycast(transform.position, Vector3.down * 100000, out RaycastHit hitInfo);
            Distance = hitInfo.distance;
        }
    }
}