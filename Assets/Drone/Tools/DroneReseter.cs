using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(DroneStabilizator))]
public class DroneReseter : MonoBehaviour
{
    private Rigidbody droneBody;
    private DroneStabilizator stabilizator;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    public void SetResetTransform(Vector3 pos, Quaternion rot)
    {
        initialPosition = pos;
        initialRotation = rot;
    }

    private void Start()
    {
        droneBody = GetComponent<Rigidbody>();
        stabilizator = GetComponent<DroneStabilizator>();
        
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.R))
        {
            return;
        }

        droneBody.transform.position = initialPosition;
        droneBody.transform.rotation = initialRotation;
        droneBody.velocity = Vector3.zero;
        droneBody.angularVelocity = Vector3.zero;
        stabilizator.Reset();
    }
}
