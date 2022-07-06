using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePID : MonoBehaviour
{
    public PID PID;
    [Range(0, 1)]
    public float StabilizationPower = 0.5f;
    public float MinValue = 0;
    public float MaxValue = 1;

    public float GetValue(float p, float dt)
    {
        float clampedValue = Mathf.Clamp(PID.Update(p, dt), MinValue, MaxValue);
        return clampedValue * StabilizationPower;
    }

    public void Reset()
    {
        PID.Reset();
    }
}
