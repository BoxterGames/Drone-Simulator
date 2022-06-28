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

    public override void Init(float initialValue)
    {
        CurrentValue = initialValue;
        Force = -G;
        Velocity = 0;
    }

    public override void NextFrame(float dt)
    {
        //For simplify we ignore that motor need time to start rotation
        CurrentValue += Velocity * dt;
        Velocity += (Force + G) * dt;

        float value = HeightPID.Update(IdealValue - CurrentValue, dt);
        Force = MotorForce * Mathf.Clamp01(value) * HeightPower;
    }
}
