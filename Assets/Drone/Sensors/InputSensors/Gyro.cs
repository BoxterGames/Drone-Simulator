using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sensors.Input
{
	public class Gyro : InputSensor
	{
		public Rigidbody RigidBody;

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