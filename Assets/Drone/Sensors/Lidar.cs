using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lidar : MonoBehaviour
{
    public float Distance { get; private set; }
    public float Speed { get; private set; }

    private float prevDistance;

    private void LateUpdate()
    {
        Physics.Raycast(transform.position, Vector3.down * 100000, out RaycastHit hitInfo);
        Distance = hitInfo.distance;

        if (Distance != prevDistance)
        {
            Speed = (Distance - prevDistance) / Time.deltaTime;
        }

        prevDistance = Distance;
    }
}
