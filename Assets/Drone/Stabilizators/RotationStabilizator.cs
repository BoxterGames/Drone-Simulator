using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensors;

namespace Stabilizators
{
    public class RotationStabilizator : AbstractStabilizator
    {
        public float BankLimit = 25;

        [Range(0, 1)]
        public float StabllizationPower = 0.5f;

        public override float CalculateMotorsPower(DroneControlllerData data, SensorsData sensorsData)
        {
            float input = Type == StabilizationType.Roll ? data.Roll : data.Pitch;
            float value = Type == StabilizationType.Roll ? sensorsData.EulerAngles.z : sensorsData.EulerAngles.x;

            float correction = PID.Update(input * BankLimit - value, Time.deltaTime);
            return Mathf.Clamp(correction, -1, 1) * StabllizationPower;
        }
    }
}
