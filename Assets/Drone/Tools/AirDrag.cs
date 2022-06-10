using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AirDrag : MonoBehaviour
{
    [Range(0, 0.1f)]
    public float Drag = 0.01f;

    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigidBody.velocity *= 1 - Drag;
    }
}
