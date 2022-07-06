using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensors;

namespace Stabilizators
{
    public class HeightStabilizator : AbstractStabilizator
    {
        public VelocityPID VelocityPID;

        public override float CalculateMotorsPower(DroneControlllerData data, SensorsData sensorsData, float dt)
        {
            float p = data.Height - sensorsData.Height;
            return VelocityPID.GetValue(p, sensorsData.HeightVelocity, dt);
        }

        public override void Reset()
        {
            VelocityPID.Reset();
        }
    }
}
