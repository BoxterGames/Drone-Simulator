using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Sensors.Input
{
    public abstract class InputSensor : MonoBehaviour
    {
        public abstract void FillSensorsData(Dictionary<StabilizationType, float> data);

        protected void AddValue(Dictionary<StabilizationType, float> data, StabilizationType key, float value)
        {
            if (!data.ContainsKey(key))
            {
                data.Add(key, 0);
            }

            data[key] += value;
        }
    }
}
