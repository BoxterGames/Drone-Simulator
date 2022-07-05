using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmulatorVisualizer : MonoBehaviour
{
    public RecordPlayer Record;
    public AbstractEmulator Emulator;

    public Color VisualizeColor = Color.blue;

    private List<Vector2> currentValues = new List<Vector2>();
    private List<Vector2> idealValues = new List<Vector2>();

    private void Start()
    {
        Record.OnReset += ResetEmulator;
        Record.OnNextFrame += NextFrame;
    }

    private void LateUpdate()
    {
        Visualize();
    }

    public void ResetEmulator()
    {
        currentValues.Clear();
        idealValues.Clear();
        Emulator.ResetEmulator();
    }

    public void NextFrame(FrameData data)
    {
        Emulator.NextFrame(data);
        currentValues.Add(new Vector2(data.Time, Emulator.CurrentValue));
        idealValues.Add(new Vector2(data.Time, Emulator.IdealValue));
    }

    private void Visualize()
    {
        for (int i = 1; i < currentValues.Count; i++)
        {
            Debug.DrawLine(currentValues[i - 1], currentValues[i], VisualizeColor);
            Debug.DrawLine(idealValues[i - 1], idealValues[i], Color.green);
        }
    }
}
