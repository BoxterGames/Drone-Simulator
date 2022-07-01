using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensors;

namespace Stabilizators
{
    public class HeightStabilizator : AbstractStabilizator
    {
        public override float CalculateMotorsPower(DroneControlllerData data, SensorsData sensorsData)
        {
            float heightPower = PID.Update(data.Height - sensorsData.Height, Time.deltaTime);
            return Mathf.Clamp(heightPower, 0, 1);
        }
    }
}
