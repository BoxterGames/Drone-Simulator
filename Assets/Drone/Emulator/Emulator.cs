using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEmulator : MonoBehaviour
{
    public float CurrentValue;
    public float IdealValue;

    public abstract void Init(float initialValue);
    public abstract void NextFrame(float dt);
}
