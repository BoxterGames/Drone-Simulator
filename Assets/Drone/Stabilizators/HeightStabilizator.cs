using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensors;

namespace Stabilizators
{
    public class HeightStabilizator : AbstractStabilizator
    {
        public override float CalculateMotorsPower(DroneControlllerData data, SensorsData sensorsData, float dt)
        {
            float heightPower = PID.Update(data.Height - sensorsData.Height, dt);
            return Mathf.Clamp(heightPower, 0, 1);
        }
    }
}
