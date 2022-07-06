using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityPID : MonoBehaviour
{
    public SimplePID ValueToSpeed;
    public SimplePID SpeedToPower;
    public float MaximumSpeed;

    public float GetValue(float p, float speed, float dt)
    {
        float idealSpeed = MaximumSpeed * ValueToSpeed.GetValue(p, dt);
        float pSpeed = idealSpeed - speed;
        return SpeedToPower.GetValue(pSpeed, dt);
    }
    
    public void Reset()
    {
        ValueToSpeed.Reset();
        SpeedToPower.Reset();
    }
}
