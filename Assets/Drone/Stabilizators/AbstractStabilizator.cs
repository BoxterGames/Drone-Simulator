using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractStabilizator : MonoBehaviour
{
    public PID PID;
    public int MotorCount;
    public abstract float[] CalculateMotorsPower(DroneControlllerData data);

    public void Reset()
    {
        PID.Reset();
    }
}
