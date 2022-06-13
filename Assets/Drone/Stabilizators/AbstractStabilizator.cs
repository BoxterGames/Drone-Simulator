using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractStabilizator : MonoBehaviour
{
    public StabilizationType Type;
    public PID PID;
    public int MotorCount;
    public abstract float CalculateMotorsPower(DroneControlllerData data);

    public virtual void Reset()
    {
        PID.Reset();
    }
}
