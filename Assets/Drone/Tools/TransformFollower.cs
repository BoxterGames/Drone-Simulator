using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFollower : MonoBehaviour
{
    public Transform ObjectToFollow;
    public float ZOffset = -31;
    public float YOffset = 21;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = ObjectToFollow.position + ObjectToFollow.forward * ZOffset + Vector3.up * YOffset;
        transform.LookAt(ObjectToFollow);
    }
}
