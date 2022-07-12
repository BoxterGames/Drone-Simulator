using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensors;

public class DistanceEmulator : AbstractEmulator
{
    public SimplePID PID;

    [Header("Settings")]
    public float MaximumDistance = 5;
    public float MaximumAngle = 30;

    public float MotorPower;

    [Header("Data to log")]
    public float Angle;
    public float Velocity;

    public override void ResetEmulator()
    {
        Velocity = 0;
        CurrentValue = 0;
        PID.Reset();
    }

    public override void NextFrame(FrameData data)
    {
        IdealValue = data.IdealData * MaximumDistance;
        CalculatePhysics(data);

        Angle = MaximumAngle * PID.GetValue(IdealValue - CurrentValue, data.DeltaTime);
    }

    private void CalculatePhysics(FrameData data)
    {
        float acceleration = Mathf.Sin(Angle * Mathf.Deg2Rad) * MotorPower;
        CurrentValue += Velocity * data.DeltaTime;
        Velocity += acceleration * data.DeltaTime;
    }
}
