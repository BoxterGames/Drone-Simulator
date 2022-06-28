using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct FrameData
{
    public float Time;
    public float IdealData;
    public float DeltaTime;
}

public class RecordPlayer : MonoBehaviour
{
    public Action<FrameData> OnNextFrame;
    public Action OnReset;

    [Header("Time")]
    public float Time;
    public float TimeEnd = 20;
    public float FrameFrequency;

    [Header("Input")]
    public AnimationCurve IdealData;

    private void Update()
    {
        ResetEmulator();

        while (Time < TimeEnd)
        {
            NextFrame();
        }
    }

    public void NextFrame()
    {
        Time += FrameFrequency;
        OnNextFrame(new FrameData()
        {
            DeltaTime = FrameFrequency,
            Time = Time,
            IdealData = IdealData.Evaluate(Time)
        });
    }

    public void ResetEmulator()
    {
        Time = 0;
        OnReset();
    }
}
