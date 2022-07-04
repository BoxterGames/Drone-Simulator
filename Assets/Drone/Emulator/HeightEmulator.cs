using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensors;

public class HeightEmulator : AbstractEmulator
{
    [Header("Copter settings")]
    public float MotorForce = -3 * G;

    [Header("Data to log")]
    public float Velocity;
    public float Force;
    public float MaximumSpeed;

    private const float G = -9.8f;

    public override void ResetEmulator()
    {
        Stabilizator.Reset();
        CurrentValue = 0;
        Force = -G;
        Velocity = 0;
    }

    public override void NextFrame(FrameData data)
    {
        IdealValue = data.IdealData * MaximumSpeed;

        var sensors = CalculatePhysics(data);
        var input = new DroneControlllerData() { Height = data.IdealData };
        Force = MotorForce * Stabilizator.CalculateMotorsPower(input, sensors, data.DeltaTime);
    }

    public SensorsData CalculatePhysics(FrameData data)
    {
        //For simplify we ignore that motor need time to start rotation
        CurrentValue += Velocity * data.DeltaTime;
        Velocity += (Force + G) * data.DeltaTime;
        CurrentValue = Velocity;

        return new SensorsData()
        {
            Height = CurrentValue,
            HeightVelocity = Velocity
        };
    }
}
