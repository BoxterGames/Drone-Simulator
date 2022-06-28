using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEmulator : MonoBehaviour
{
    public float CurrentValue;
    public float IdealValue;

    public abstract void ResetEmulator();
    public abstract void NextFrame(FrameData data);
}
