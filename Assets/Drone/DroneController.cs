using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DroneControlllerData
{
    public float Roll;
    public float Pitch;
    public float YawSpeed;
    public float Height;

    public DroneControlllerData(float roll, float pitch, float height, float yawSpeed)
    {
        Roll = roll;
        Pitch = pitch;
        Height = height;
        YawSpeed = yawSpeed;
    }
}

public class DroneController : MonoBehaviour
{
    public DroneStabilizator Drone;
    public float Height = 5;
    public float HeightSpeed = 1;
    void Update()
    {
        float roll = 0;
        float pitch = 0;
        float yaw = 0;

        if (Input.GetKey(KeyCode.A)) roll = 1;
        if (Input.GetKey(KeyCode.D)) roll = -1;
        if (Input.GetKey(KeyCode.W)) pitch = 1;
        if (Input.GetKey(KeyCode.S)) pitch = -1;
        if (Input.GetKey(KeyCode.Q)) yaw = -1;
        if (Input.GetKey(KeyCode.E)) yaw = 1;
        if (Input.GetKey(KeyCode.LeftShift)) Height += HeightSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftControl)) Height -= HeightSpeed * Time.deltaTime;
        Drone.UpdateComputer(new DroneControlllerData(roll, pitch, Height, yaw));
    }
}
