using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensors;

public class YawEmulator : AbstractEmulator
{
    [Header("Copter settings")]
    public float MotorSideForce = 3 * G * 0.3f;
    public float Radius = 0.1f;

    [Header("Data to log")]
    public float AngularVelocity;
    public float Force;
    public float MaximumSpeed;

    private const float G = -9.8f;

    public override void ResetEmulator()
    {
        Stabilizator.Reset();
        CurrentValue = 0;
        Force = 0;
        AngularVelocity = 0;
    }

    public override void NextFrame(FrameData data)
    {
        IdealValue = AngleNormalizer.NormalizeAngle(data.IdealData * 360);

        var sensors = CalculatePhysics(data);
        var input = new DroneControlllerData() { Yaw = IdealValue };
        Force = MotorSideForce * Stabilizator.CalculateMotorsPower(input, sensors, data.DeltaTime);
    }

    public SensorsData CalculatePhysics(FrameData data)
    {
        float angularAcceleration = Force / (Radius * Radius);
        CurrentValue += AngularVelocity * data.DeltaTime;
        AngularVelocity += angularAcceleration * data.DeltaTime * Mathf.Rad2Deg;

        CurrentValue = AngleNormalizer.NormalizeAngle(CurrentValue);

        return new SensorsData()
        {
            EulerAngles = CurrentValue * Vector3.one,
            AngularVelocity = AngularVelocity * Vector3.one 
        };
    }
}
