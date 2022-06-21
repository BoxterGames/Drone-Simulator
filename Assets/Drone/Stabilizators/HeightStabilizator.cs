using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightStabilizator : AbstractStabilizator
{
    public Lidar Lidar;
    [Range(0,1)]
    public float AntigravityPower = 0.2f;

    public float VerticalSpeed = 2;

    public PID PidHeight;


    public override float CalculateMotorsPower(DroneControlllerData data)
    {
        float deltaHeight = data.Height - Lidar.Distance;
        float input = PidHeight.Update(deltaHeight, Time.deltaTime);

        input = Mathf.Clamp(input, -1, 1);

        float speed = Lidar.Speed;
        float idealSpeed = input * VerticalSpeed;
        float heightPower = PID.Update(idealSpeed - speed, Time.deltaTime);
     //   Debug.Log(idealSpeed + " " + speed);

        return Mathf.Clamp(heightPower, AntigravityPower, 1);
    }
}
