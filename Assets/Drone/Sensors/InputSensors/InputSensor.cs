using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Sensors.Input
{
    public abstract class InputSensor : MonoBehaviour
    {
        public abstract void FillSensorsData(ref SensorsData data);
    }
}
