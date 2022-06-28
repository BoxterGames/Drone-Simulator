using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmulatorManager : MonoBehaviour
{
    public AbstractEmulator Emulator;

    public float Time;

    public float TimeEnd = 20;
    public float FrameFrequency;

    private List<Vector2> currentValues = new List<Vector2>();
    private List<Vector2> idealValues = new List<Vector2>();

    private void Update()
    {
        Emulator.Init(0);
        Emulator.IdealValue = 10;
        currentValues.Clear();
        idealValues.Clear();
        Time = 0;

        while (Time < TimeEnd)
        {
            Time += FrameFrequency;
            Emulator.NextFrame(FrameFrequency);

            currentValues.Add(new Vector2(Time, Emulator.CurrentValue));
            idealValues.Add(new Vector2(Time, Emulator.IdealValue));
        }

        Visualize();
    }

    private void Visualize()
    {
        for (int i = 1; i < currentValues.Count; i++)
        {
            Debug.DrawLine(currentValues[i - 1], currentValues[i]);
            Debug.DrawLine(idealValues[i - 1], idealValues[i], Color.green);
        }
    }
}
