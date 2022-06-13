using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneStabilizator : MonoBehaviour
{
    [Header("Motors")]
    public DroneMotor[] Motors = new DroneMotor[4];

    public AbstractStabilizator[] Stabilizators;
    public MotorCorrectionMap CorrectionMap;

    private Dictionary<StabilizationType, float> stabiliztionFactors = new Dictionary<StabilizationType, float>();

    private void Start()
    {
       foreach(var i in Stabilizators)
        {
            stabiliztionFactors.Add(i.Type, 0);
        }    
    }

    public void UpdateComputer(DroneControlllerData data)
    {
        foreach (var i in Stabilizators)
        {
            stabiliztionFactors[i.Type] = i.CalculateMotorsPower(data);
        }

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
        foreach(var i in Stabilizators)
        {
            i.Reset();
        }
    }
}
