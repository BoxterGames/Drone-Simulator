using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractStabilizator : MonoBehaviour
{
    public StabilizationType Type;
    public PID PID;
    [Range(0, 1)]
    public float StabilizationPower = 0.3f;

    public abstract float CalculateMotorsPower(DroneControlllerData data);

    public virtual void Reset()
    {
        PID.Reset();
    }
}
