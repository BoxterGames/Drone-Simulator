using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerController : MonoBehaviour
{
    [Header("Simulation")]
    public bool AutoSimulate;

    public DroneStabilizator Drone;
    public DroneReseter Reseter;

    public PID SidePid;
   
    [Header("Distance")]
    public SimplePID ForwardPid;
    public FollowerCompensator Forward;
    public float ForwardOffset = 5;

    public float Height = 5;
    private float prevPitchDelta;

    private void Start()
    {
        Reseter.SetResetTransform(transform.position + new Vector3(0.01f, 0, 0.01f), transform.rotation);
    }

    private void Update()
    {
        if (AutoSimulate)
        {
            SendData(Time.deltaTime);
        }
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
        float pitch = -Forward.CalculatePower(deltaPitch.magnitude, ForwardOffset, Time.deltaTime);
        Debug.Log(deltaPitch.magnitude+" "+ForwardOffset+" "+pitch);

        //Yaw calculated
        Vector3 deltaYaw = transform.position - Drone.transform.position;
        float yaw = Vector3.SignedAngle(Vector3.forward, deltaYaw, Vector3.up);

        Drone.UpdateComputer(new DroneControlllerData(rollClamped, pitch, Height, yaw));
    }
}
