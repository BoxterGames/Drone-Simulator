using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarControl : MonoBehaviour
{
    public float Speed = 100;
    public float SideSpeed = 10;

    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.velocity += transform.forward * Speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rigid.velocity -= transform.forward * Speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 vel = rigid.angularVelocity;
            vel.y = -SideSpeed;
            rigid.angularVelocity = vel;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 vel = rigid.angularVelocity;
            vel.y = SideSpeed;
            rigid.angularVelocity = vel;
        }
    }
}
