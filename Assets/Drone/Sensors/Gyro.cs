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
		rotation = NormalizeAngle(transform.eulerAngles);
		rotationSpeed = RigidBody.angularVelocity * Mathf.Rad2Deg;
	}

	private Vector3 NormalizeAngle(Vector3 v)
	{
		return new Vector3(NormalizeAngle(v.x), NormalizeAngle(v.y), NormalizeAngle(v.z));
	}

	public float NormalizeAngle(float a)
	{
		if (a > 180)
		{
			return a - 360;

		}

		if (a < -180)
		{
			return 360 + a;
		}

		return a;
	}
}
