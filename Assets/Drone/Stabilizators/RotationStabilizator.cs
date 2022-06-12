using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationStabilizator : AbstractStabilizator
{
    public enum Axis
    {
        Roll,
        Pitch
    }

    public Axis CurrentAxis;
    public float BankLimit = 25;
    public float[] MotorCompensation = new float[4];
    public Gyro Gyroscope;
    [Range(0,1)]
    public float StabllizationPower = 0.5f;
    public override float[] CalculateMotorsPower(DroneControlllerData data)
    {
        float input = CurrentAxis == Axis.Roll ? data.Roll : data.Pitch;
        float value = CurrentAxis == Axis.Roll ? Gyroscope.Roll : Gyroscope.Pitch;

        float correction = PID.Update(input * BankLimit - value, Time.deltaTime);

        float[] power = new float[MotorCount];

        for (int i = 0; i < power.Length; i++)
        {
            power[i] = Mathf.Clamp(correction * MotorCompensation[i], -1, 1) * StabllizationPower;
        }

        return power;
    }
}
