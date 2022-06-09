using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MotorInfo
{
    public DroneMotor Motor;
    public float PitchCorrection;
    public float RollCorrection;
    public float YawCorrection;
}

public class DroneStabilizator : MonoBehaviour
{
    [Header("Motors")]
    public DroneMotor[] Motors = new DroneMotor[4];
    public AbstractStabilizator[] Stabilizators;

    public void UpdateComputer(DroneControlllerData data)
    {
        float[] motorPower = new float[Motors.Length];

        foreach (var i in Stabilizators)
        {
            var power = i.CalculateMotorsPower(data);
            
            for(int j = 0; j < motorPower.Length; j++)
            {
                motorPower[j] += power[j];
            }
        }

        for (int i = 0; i < motorPower.Length; i++)
        {
            Motors[i].UpdatePower(motorPower[i]);
        }
    }
}
