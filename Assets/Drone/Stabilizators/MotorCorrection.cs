using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StabilizationType
{
    Yaw,
    Pitch,
    Roll,
    Throttle
}

[System.Serializable]
public struct MotorCorrectionMap
{
    public float[] YawCorrection;
    public float[] PitchCorrection;
    public float[] RollCorrection;
    public float[] ThrottletCorrection;

    public float[] GetStabilization(StabilizationType type)
    {
        switch (type)
        {
            case StabilizationType.Roll:
                return RollCorrection;

            case StabilizationType.Pitch:
                return PitchCorrection;

            case StabilizationType.Throttle:
                return ThrottletCorrection;

            case StabilizationType.Yaw:
                return YawCorrection;
        }

        throw new System.Exception("Unknown correction type: " + type);
    }
}
