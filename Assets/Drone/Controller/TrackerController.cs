using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerController : MonoBehaviour
{
    public DroneStabilizator Drone;
    public PID SidePid;
    public PID ForwardPid;
    public PID yawPid;

    public float Height = 5;

    private void Update()
    {
        Vector3 localPoint = Drone.transform.InverseTransformPoint(transform.position);

        float rollRaw = SidePid.Update(0, localPoint.x, Time.deltaTime);
        float rollClamped = Mathf.Clamp(rollRaw, -1, 1);

        float pitchRaw = SidePid.Update(0, -localPoint.z, Time.deltaTime);
        float pitchClamped = Mathf.Clamp(pitchRaw, -1, 1);

        Vector3 droneFwd = Drone.transform.forward;
        droneFwd.y = 0;
        Vector3 currFwd = transform.forward;
        currFwd.y = 0;

        float deltaForward = Vector3.SignedAngle(droneFwd.normalized, currFwd.normalized, Vector3.up);
        float yawRaw = yawPid.Update(deltaForward, 0, Time.deltaTime);
        float yawClamed = Mathf.Clamp(yawRaw, -1, 1);
        Drone.UpdateComputer(new DroneControlllerData(rollClamped, pitchClamped, Height, yawClamed));
    }
}
