using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMotor : MonoBehaviour
{
    public float FlightPower = 0.5f;
    public float SidePower = 0.1f;

    [Range(-180,180)]
    public float SidePowerDirection;

    public Rigidbody DroneRigidBody;

    public float currentPower;

    [Range(0, 360)]
    float angle = 0;

    public void UpdatePower(float newPower)
    {
        currentPower = newPower;
    }

    public void Update()
    {
        Vector3 direction = new Vector3(Mathf.Sin(SidePowerDirection * Mathf.Deg2Rad), 0, Mathf.Cos(SidePowerDirection * Mathf.Deg2Rad));
        Vector3 resultPower = Vector3.up * FlightPower + SidePower * direction;
        Debug.DrawRay(transform.position, transform.rotation * direction * 20);

        DroneRigidBody?.AddForceAtPosition(transform.rotation * resultPower * currentPower, transform.position, ForceMode.Force);
    }
}
