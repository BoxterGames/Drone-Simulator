using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensors;

namespace Stabilizators
{
    public class YawStabilizator : AbstractStabilizator
    {
        [Range(0, 1)]
        public float StabilizationPower = 0.3f;
        public float YawSpeed = 45;
        private float currentYaw = 0;

        public override float CalculateMotorsPower(DroneControlllerData data, SensorsData sensorData, float dt)
        {
            currentYaw += YawSpeed * data.Yaw * Time.deltaTime;
            float value = sensorData.EulerAngles.y;
            float correction = PID.Update(AngleNormalizer.NormalizeAngle(currentYaw - value), dt);

            return Mathf.Clamp(correction, -1, 1) * StabilizationPower;
        }
    }
}
