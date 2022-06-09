using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReseter : MonoBehaviour
{
    public Rigidbody DroneBody;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = DroneBody.position;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.R))
        {
            return;
        }

        DroneBody.transform.position = initialPosition;
        DroneBody.transform.rotation = Quaternion.identity;
        DroneBody.velocity = Vector3.zero;
        DroneBody.angularVelocity = Vector3.zero;
    }
}
