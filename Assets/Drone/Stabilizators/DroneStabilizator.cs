using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensors;
using Sensors.Input;
using System;
using Stabilizators;

public class DroneStabilizator : MonoBehaviour
{
    [Header("Sensors")]
    public InputSensor[] Input;

    [Header("Motors")]
    public DroneMotor[] Motors = new DroneMotor[4];

    public AbstractStabilizator[] Stabilizators;
    public MotorCorrectionMap CorrectionMap;

    private Dictionary<StabilizationType, float> stabiliztionFactors = new Dictionary<StabilizationType, float>();

    private void Start()
    {
        Array.ForEach(Stabilizators, i => stabiliztionFactors.Add(i.Type, 0));
    }

    public void UpdateComputer(DroneControlllerData data)
    {
        var sensorsData = new SensorsData();

        Array.ForEach(Input, i => i.FillSensorsData(ref sensorsData));
        Array.ForEach(Stabilizators, i => stabiliztionFactors[i.Type] = i.CalculateMotorsPower(data, sensorsData, Time.deltaTime));

        for (int i = 0; i < Motors.Length; i++)
        {
            float resultPower = 0;

            foreach (var factor in stabiliztionFactors)
            {
                var factors = CorrectionMap.GetStabilization(factor.Key);
                resultPower += factors[i] * factor.Value;
            }

            Motors[i].UpdatePower(resultPower);
        }
    }

    public void Reset()
    {
        Array.ForEach(Stabilizators, i => i.Reset());
    }
}
