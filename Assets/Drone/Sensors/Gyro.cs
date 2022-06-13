using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{
	public Rigidbody RigidBody;

	public float Pitch { get { return rotation.x; } }
	public float Roll { get { return rotation.z; } }
	public float Yaw { get { return rotation.y; } }

	public float PitchSpeed { get { return rotationSpeed.x; } }
	public float RollSpeed { get { return rotationSpeed.z; } }
	public float YawSpeed { get { return rotationSpeed.y;  } }

	private Vector3 rotationSpeed;
	private Vector3 rotation;
	private Quaternion prevRotation;

	public void Update()
	{
		rotation = AngleNormalizer.NormalizeAngle(transform.eulerAngles);
		rotationSpeed = RigidBody.angularVelocity * Mathf.Rad2Deg;
	}
}
