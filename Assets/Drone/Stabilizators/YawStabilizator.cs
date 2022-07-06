using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensors;

namespace Stabilizators
{
    public class YawStabilizator : AbstractStabilizator
    {
        public VelocityPID VelocityPID;

        public override float CalculateMotorsPower(DroneControlllerData data, SensorsData sensorData, float dt)
        {
            float p = AngleNormalizer.NormalizeAngle(data.Yaw - sensorData.EulerAngles.y);
            return VelocityPID.GetValue(p, sensorData.AngularVelocity.y, dt);
        }

        public override void Reset()
        {
            VelocityPID.Reset();
        }
    }
}
