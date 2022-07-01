using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stabilizators;

public abstract class AbstractEmulator : MonoBehaviour
{
    public AbstractStabilizator Stabilizator;
    public float CurrentValue;
    public float IdealValue;

    public abstract void ResetEmulator();
    public abstract void NextFrame(FrameData data);
}
