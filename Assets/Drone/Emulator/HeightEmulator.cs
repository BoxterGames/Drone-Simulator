using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightEmulator : AbstractEmulator
{
    [Header("Copter settings")]
    public float MotorForce = 3 * G;

    [Header("Input settings")]
    public PID HeightPID;
    public float HeightPower = 0.6f;

    [Header("Data to log")]
    public float Velocity;
    public float Force;

    private const float G = -9.8f;

    public override void ResetEmulator()
    {
        CurrentValue = 0;
        Force = -G;
        Velocity = 0;
    }

    public override void NextFrame(FrameData data)
    {
        IdealValue = data.IdealData;

        //For simplify we ignore that motor need time to start rotation
        CurrentValue += Velocity * data.DeltaTime;
        Velocity += (Force + G) * data.DeltaTime;

        float value = HeightPID.Update(IdealValue - CurrentValue, data.DeltaTime);
        Force = MotorForce * Mathf.Clamp01(value) * HeightPower;
    }
}
