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

    private float power;

    public void UpdatePower(float newPower)
    {
        power = newPower;
    }

    public void Update()
    {
        Vector3 direction = new Vector3(Mathf.Sin(SidePowerDirection * Mathf.Deg2Rad), 0, Mathf.Cos(SidePowerDirection * Mathf.Deg2Rad));
        Vector3 resultPower = Vector3.up * FlightPower + SidePower * direction;

        DroneRigidBody?.AddForceAtPosition(transform.rotation * resultPower * power, transform.position, ForceMode.Force);
    }
}
