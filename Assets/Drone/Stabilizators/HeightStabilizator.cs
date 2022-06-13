using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightStabilizator : AbstractStabilizator
{
    public Lidar Lidar;

    public override float CalculateMotorsPower(DroneControlllerData data)
    {
        float heightPower = PID.Update(data.Height - Lidar.Distance, Time.deltaTime);
        return Mathf.Clamp(heightPower, 0, 1);
    }
}
