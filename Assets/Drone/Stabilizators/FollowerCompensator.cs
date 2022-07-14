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
    public float DistanceP = 1;
    public float SpeedP = 1;
    public float TimeP = 1;

    public AnimationCurve ReversePower;

    [SerializeField] private float minValue = -1;
    [SerializeField] private float maxValue = 1;

    private SpeedCalculator calculator = new SpeedCalculator();
    private float prevValue;

    public float CalculatePower(float currentValue, float idealValue, float deltaTime)
    {
        float distance = idealValue - currentValue;
        float speed = calculator.CalculateSpeed((currentValue - prevValue) / deltaTime);
        float time = distance / speed;
        prevValue = currentValue;

        float distanceValue = Clamp(distance * DistanceP);
        float timeValue = Clamp(time * TimeP);
        float speedValue = Clamp(speed * SpeedP);

        Debug.Log(distance + " " + time + " " + speed);


        if (Math.Sign(distance) != Math.Sign(speed))
        {
            return -speedValue;
        }
        else
        {
            return Mathf.Min(distanceValue, timeValue);
        }
    }

    private float Clamp(float value)
    {
        return Mathf.Clamp(value, minValue, maxValue);
    }
}
