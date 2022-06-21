using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YawStabilizator : AbstractStabilizator
{
    public Gyro Gyroscope;
 
    public float YawSpeed = 45;

    public override float CalculateMotorsPower(DroneControlllerData data)
    {
        float idealSpeed = data.Yaw * YawSpeed;
        float currentSpeed = Gyroscope.YawSpeed;

        float delta = idealSpeed - currentSpeed;
        float correction = PID.Update(delta, Time.deltaTime);

        return Mathf.Clamp(correction, -1, 1) * StabilizationPower;
    }
}
