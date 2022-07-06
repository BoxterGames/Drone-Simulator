using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DroneControlllerData
{
    public float Roll;
    public float Pitch;
    public float Yaw;
    public float Height;

    public DroneControlllerData(float roll, float pitch, float height, float yaw)
    {
        Roll = roll;
        Pitch = pitch;
        Height = height;
        Yaw = yaw;
    }
}

public class DroneController : MonoBehaviour
{
    public DroneStabilizator Drone;
    
    public float HeightSpeed = 1;
    public float YawSpeed = 360;

    private float currentHeight = 5;
    private float currentYaw;

    private float initialYaw;
    private float initialHeight;

    private void Start()
    {
        initialHeight = currentHeight = Drone.transform.position.y;
        initialYaw = currentYaw = Drone.transform.eulerAngles.y;
    }

    void LateUpdate()
    {
        float roll = 0;
        float pitch = 0;

        if (Input.GetKey(KeyCode.A)) roll = 1;
        if (Input.GetKey(KeyCode.D)) roll = -1;
        if (Input.GetKey(KeyCode.W)) pitch = 1;
        if (Input.GetKey(KeyCode.S)) pitch = -1;
        if (Input.GetKey(KeyCode.Q)) currentYaw -= YawSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.E)) currentYaw += YawSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift)) currentHeight += HeightSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftControl)) currentHeight -= HeightSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentHeight = initialHeight;
            currentYaw = initialYaw;
        }
        Debug.DrawRay(Drone.transform.position, new Vector3(Mathf.Sin(currentYaw * Mathf.Deg2Rad), 0, Mathf.Cos(currentYaw * Mathf.Deg2Rad)) * 100);
        Drone.UpdateComputer(new DroneControlllerData(roll, pitch, currentHeight, currentYaw));
    }
}
