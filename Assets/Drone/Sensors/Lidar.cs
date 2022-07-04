using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sensors.Input
{
    public class Lidar : InputSensor
    {
        public float Distance { get; private set; }
        public float Velocity { get; private set; }

        private float prevDistance;
        public override void FillSensorsData(ref SensorsData data)
        {
            data.Height = Distance;
            data.HeightVelocity = Velocity;
        }

        private void FixedUpdate()
        {
            Physics.Raycast(transform.position, Vector3.down * 100000, out RaycastHit hitInfo);
            Distance = hitInfo.distance;
            Velocity = (Distance - prevDistance) / Time.deltaTime;
            prevDistance = Distance;
        }
    }
}