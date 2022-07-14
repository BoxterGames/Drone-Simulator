using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrackerController : MonoBehaviour
{
    public DroneStabilizator Drone;
    public DroneReseter Reseter;

    public PID SidePid;
    public PID ForwardPid;

    public float ForwardOffset = 15;
    public float Height = 5;

    private void Start()
    {
        Reseter.SetResetTransform(transform.position + new Vector3(0.01f, 0, 0.01f), transform.rotation);
    }

    private void Update()
    {
        SendData(Time.deltaTime);
    }

    public void SendData(float deltaTime)
    {
        Vector3 localPoint = Drone.transform.InverseTransformPoint(transform.position);

        //Roll calculated
        float rollRaw = SidePid.Update(-localPoint.x, Time.deltaTime);
        float rollClamped = Mathf.Clamp(rollRaw, -1, 1);

        //Pitch caclculated
        var deltaPitch = (Drone.transform.position - transform.position);
        deltaPitch.y = 0;
        float pitch = ForwardPid.Update(ForwardOffset - deltaPitch.magnitude, Time.deltaTime);

        //Yaw calculated
        Vector3 deltaYaw = transform.position - Drone.transform.position;
        float yaw = Vector3.SignedAngle(Vector3.forward, deltaYaw, Vector3.up);

        Drone.UpdateComputer(new DroneControlllerData(rollClamped, pitch, Height, yaw));
    }
}
