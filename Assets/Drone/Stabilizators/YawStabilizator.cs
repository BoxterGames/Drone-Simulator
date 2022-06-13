using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YawStabilizator : AbstractStabilizator
{
    public Gyro Gyroscope;
    public float StabilizationPower = 0.3f;
    public float YawSpeed = 45;
    private float currentYaw = 0;

    public override float CalculateMotorsPower(DroneControlllerData data)
    {
        currentYaw += YawSpeed * data.Yaw * Time.deltaTime;
        float value = Gyroscope.Yaw;
        float correction = PID.Update(AngleNormalizer.NormalizeAngle(currentYaw - value), Time.deltaTime);

        return Mathf.Clamp(correction, -1, 1);
    }
}
