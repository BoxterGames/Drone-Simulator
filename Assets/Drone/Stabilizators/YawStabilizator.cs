using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensors;

namespace Stabilizators
{
    public class YawStabilizator : AbstractStabilizator
    {
        public PID Speed;
        public float MaximumSpeed = 360;

        public override float CalculateMotorsPower(DroneControlllerData data, SensorsData sensorData, float dt)
        {
            float delta = AngleNormalizer.NormalizeAngle(data.Yaw - sensorData.EulerAngles.y);
            float input = Mathf.Clamp(PID.Update(delta, dt), -1, 1);

            float deltaSpeed = MaximumSpeed * input - sensorData.AngularVelocity.y;
            float motorPower = Mathf.Clamp(Speed.Update(deltaSpeed, dt), -1, 1);

            return motorPower;
        }

        public override void Reset()
        {
            base.Reset();
            Speed.Reset();
        }
    }
}
