using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightStabilizator : AbstractStabilizator
{
    public Lidar Lidar;

    public override float[] CalculateMotorsPower(DroneControlllerData data)
    {
        float heightPower = PID.Update(data.Height - Lidar.Distance, Time.deltaTime);
        heightPower = Mathf.Clamp(heightPower, 0, 1);

        float[] power = new float[MotorCount];

        for (int i = 0; i < power.Length; i++)
        {
            power[i] = heightPower;
        }

        return power;
    }
}
