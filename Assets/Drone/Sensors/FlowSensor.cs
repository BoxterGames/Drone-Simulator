using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowSensor : MonoBehaviour
{
    public Vector3 LinearVelocity;
    private Vector3 prevPoint;

    private void FixedUpdate()
    {
        Vector3 globalVelocity = (transform.position - prevPoint) / Time.deltaTime;
        prevPoint = transform.position;


        //Physics.Raycast(transform.position, Vector3.down * 100000, out RaycastHit hitInfo);

        //Vector3 globalVelocity = (hitInfo.point - prevPoint) / Time.deltaTime;
        LinearVelocity = transform.InverseTransformVector(globalVelocity);
        LinearVelocity = new Vector3(LinearVelocity.x, 0, LinearVelocity.z);
        //prevPoint = hitInfo.point;
    }
}
