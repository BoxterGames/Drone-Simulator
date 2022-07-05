using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sensors.Input
{

	public class Gyro : InputSensor
	{
		public Rigidbody RigidBody;

		public float Pitch { get { return rotation.x; } }
		public float Roll { get { return rotation.z; } }
		public float Yaw { get { return rotation.y; } }

		public float PitchSpeed { get { return rotationSpeed.x; } }
		public float RollSpeed { get { return rotationSpeed.z; } }
		public float YawSpeed { get { return rotationSpeed.y; } }

		private Vector3 rotationSpeed;
		private Vector3 rotation;

		public void Update()
		{
			rotation = AngleNormalizer.NormalizeAngle(transform.eulerAngles);
			rotationSpeed = RigidBody.angularVelocity * Mathf.Rad2Deg;
		}

		public override void FillSensorsData(ref SensorsData data)
		{
			data.EulerAngles = rotation;
			data.AngularVelocity = rotationSpeed;
		}
	}
}