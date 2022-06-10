using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YawStabilizator : AbstractStabilizator
{
    public float[] MotorCompensation = new float[4];
    public Gyro Gyroscope;
    public float StabilizationPower = 0.3f;
    public float YawSpeed = 100;
    public override float[] CalculateMotorsPower(DroneControlllerData data)
    {
        float input = data.YawSpeed * YawSpeed;
        float value = Gyroscope.YawSpeed;

        float correction = PID.Update(input, value, Time.deltaTime);

        float[] power = new float[MotorCount];

        for (int i = 0; i < power.Length; i++)
        {
            power[i] = Mathf.Clamp(correction * MotorCompensation[i], -1, 1) * StabilizationPower;
        }

        return power;
    }
}
