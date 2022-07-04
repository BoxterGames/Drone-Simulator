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
            float delta = data.Height - sensorsData.Height;
            float input = Mathf.Clamp(PID.Update(delta, dt), -1, 1);

            float deltaSpeed = MaximumSpeed * input - sensorsData.HeightVelocity;
            float motorPower = Mathf.Clamp01(Speed.Update(deltaSpeed, dt));
            Debug.Log(input + " " + motorPower);
            return motorPower;
        }

        public override void Reset()
        {
            base.Reset();
            Speed.Reset();
        }
    }
}
