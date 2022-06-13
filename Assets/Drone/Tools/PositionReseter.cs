using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReseter : MonoBehaviour
{
    public Rigidbody DroneBody;
    public DroneStabilizator Stabilizator;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    public void SetResetTransform(Vector3 pos, Quaternion rot)
    {
        initialPosition = pos;
        initialRotation = rot;
    }

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.R))
        {
            return;
        }

        DroneBody.transform.position = initialPosition;
        DroneBody.transform.rotation = initialRotation;
        DroneBody.velocity = Vector3.zero;
        DroneBody.angularVelocity = Vector3.zero;
        Stabilizator.Reset();
    }
}
