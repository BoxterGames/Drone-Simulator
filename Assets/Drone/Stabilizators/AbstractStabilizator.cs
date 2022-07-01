using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensors;

namespace Stabilizators
{
    public abstract class AbstractStabilizator : MonoBehaviour
    {
        public StabilizationType Type;
        public PID PID;

        public abstract float CalculateMotorsPower(DroneControlllerData data, SensorsData sensorData, float dt);

        public virtual void Reset()
        {
            PID.Reset();
        }
    }
}
