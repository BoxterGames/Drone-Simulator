using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lidar : MonoBehaviour
{
    public float Distance { get; private set; }

    private void Update()
    {
        Physics.Raycast(transform.position, Vector3.down * 100000, out RaycastHit hitInfo);
        Distance = hitInfo.distance;
    }
}
