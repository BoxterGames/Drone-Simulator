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

    public void UpdatePower(float newPower)
    {
        currentPower = Mathf.Clamp01(newPower);
    }

    public void Update()
    {
        Vector3 direction = new Vector3(Mathf.Sin(SidePowerDirection * Mathf.Deg2Rad), 0, Mathf.Cos(SidePowerDirection * Mathf.Deg2Rad));
        Vector3 resultPower = Vector3.up * FlightPower + SidePower * direction;

        DroneRigidBody?.AddForceAtPosition(transform.rotation * resultPower * currentPower, transform.position, ForceMode.Force);
    }
}
