using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensors;

namespace Stabilizators
{
    public class RotationStabilizator : AbstractStabilizator
    {
        public float BankLimit = 25;
        public SimplePID SimplePID;

        public override float CalculateMotorsPower(DroneControlllerData data, SensorsData sensorsData, float dt)
        {
            float input = Type == StabilizationType.Roll ? data.Roll : data.Pitch;
            float value = Type == StabilizationType.Roll ? sensorsData.EulerAngles.z : sensorsData.EulerAngles.x;
            return SimplePID.GetValue(input * BankLimit - value, dt);
        }

        public override void Reset()
        {
            SimplePID.Reset();
        }
    }
}
