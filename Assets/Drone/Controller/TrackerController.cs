using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerController : MonoBehaviour
{
    public DroneStabilizator Drone;
    public DroneReseter Reseter;

    public PID SidePid;
    public PID ForwardPid;
    public PID YawPid;

    public float Height = 5;

    private void Start()
    {
        Reseter.SetResetTransform(transform.position + new Vector3(0.01f, 0, 0.01f), transform.rotation);
    }

    private void Update()
    {
        Reseter.SetResetTransform(transform.position, transform.rotation);

        Vector3 localPoint = Drone.transform.InverseTransformPoint(transform.position);

        //Roll calculated
        float rollRaw = SidePid.Update(-localPoint.x, Time.deltaTime);
        float rollClamped = Mathf.Clamp(rollRaw, -1, 1);

        //Pitch caclculated
        float pitchRaw = ForwardPid.Update(localPoint.z, Time.deltaTime);
        float pitchClamped = Mathf.Clamp(pitchRaw, -1, 1);

        //Yaw calculated
        float delta = Vector3.SignedAngle(Vector3.forward, transform.position - Drone.transform.position, Vector3.up);

        Drone.UpdateComputer(new DroneControlllerData(rollClamped, pitchClamped, Height, delta));
    }
}
