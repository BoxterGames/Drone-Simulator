using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpeedCalculator
{
    private const float limit = 5;

    private List<float> values = new List<float>();

    public float CalculateSpeed(float speed)
    {
        values.Add(speed);
        if (values.Count > limit)
        {
            values.RemoveAt(0);
        }

        float sumSpeed = 0;
        values.ForEach(x => sumSpeed += x);
        return sumSpeed / values.Count;
    }

    public void Reset()
    {
        values.Clear();
    }
}

[Serializable]
public class FollowerCompensator
{
    public AnimationCurve Power;
    private SpeedCalculator calculator = new SpeedCalculator();
    private float prevValue;

    public float CalculatePower(float currentValue, float idealValue, float deltaTime)
    {
        float speed = calculator.CalculateSpeed((currentValue - prevValue) / deltaTime);
        prevValue = currentValue;

        float delta = idealValue - currentValue;

        if (Math.Sign(delta) != Math.Sign(speed))
        {
            //Maximum drag
            return Mathf.Clamp(Math.Sign(delta), -1, 1);
        }
        else
        {
            float time = delta / speed;
            float power = Math.Sign(delta) * Power.Evaluate(time);

            return Mathf.Clamp(power, -1, 1);
        }
    }
}
