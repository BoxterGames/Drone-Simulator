using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensors;

namespace Stabilizators
{
    public class HeightStabilizator : AbstractStabilizator
    {
        [Header("Drag part")]
        public PID Speed;
        public float MaximumSpeed;

        public override float CalculateMotorsPower(DroneControlllerData data, SensorsData sensorsData, float dt)
        {
            float delta = MaximumSpeed * data.Height - sensorsData.HeightVelocity;
            float heightPower = Speed.Update(delta, dt);
            float clampedPower = Mathf.Clamp(heightPower, 0, 1);

            return clampedPower;
        }

        public override void Reset()
        {
            base.Reset();
            Speed.Reset();
        }
    }
}
